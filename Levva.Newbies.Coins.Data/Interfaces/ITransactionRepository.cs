using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
       Task<(List<Transaction> transactions, int totalPages)> GetAll(string? search, int limit = 10, int offset = 1);

        Task<Transaction> CheckIfTransactionExists(Guid id);

       Task<string> GetTransactionByCategoryId(Guid categoryId);
    }
}
