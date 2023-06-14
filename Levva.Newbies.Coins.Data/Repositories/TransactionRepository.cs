using Levva.Newbies.Coins.Data;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levva.Newbies.Coins.Data.Repositories {
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository {

        public TransactionRepository(IContext context) : base(context) { }

        public async Task<Transaction> CheckIfTransactionExists(Guid id) {
            return await Context.Set<Transaction>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<(List<Transaction> transactions, int totalPages)> GetAll(string? search, int limit = 10, int offset = 1) {
            IQueryable<Transaction> query = Entity.Include(e => e.Category)
                                                  .Include(e => e.User)
                                                  .OrderByDescending(e => e.CreatedAt);

            

            if (!string.IsNullOrEmpty(search)) {
                query = query.Where(e =>
                     (e.Description != null && EF.Functions.Like(e.Description, $"%{search}%")) ||
                     (e.Category != null && e.Category.Description != null && EF.Functions.Like(e.Category.Description, $"%{search}%"))
                 );
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / limit);

            var transactions = await query.Skip((offset - 1) * limit)
                                          .Take(limit)
                                          .ToListAsync();

            return (transactions, totalPages);
        }


        public async Task<string> GetTransactionByCategoryId(Guid categoryId) {
            var transaction = await Entity
                                    .Include(e => e.Category)
                                    .FirstOrDefaultAsync(x => x.CategoryId == categoryId);

            if (transaction != null && transaction.Category != null) {
                return transaction.Category.Description;
            }
            return string.Empty;
        }
    }
}

