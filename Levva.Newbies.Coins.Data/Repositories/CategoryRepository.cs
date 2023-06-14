using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levva.Newbies.Coins.Data.Repositories {
    public class CategoryRepository : Repository<Category>, ICategoryRepository {

        public CategoryRepository(IContext context) : base(context) { }

        public async Task<Category> CheckCategoryExists(Guid id) {
            return await Context.Set<Category>().FirstOrDefaultAsync(c => c.Id == id);  
        }

        public async Task<Category> CheckDescriptionAlreadyExists(string description) {
            return await Context.Set<Category>().FirstOrDefaultAsync(x => x.Description == description);
        }

        public async Task<List<Category>> GetAllCategories() {
            return await Context.Set<Category>().OrderBy(c => c.Description).ToListAsync();
        }
    }
}
