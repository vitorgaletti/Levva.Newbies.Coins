using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> CheckCategoryExists(Guid id);
        Task<Category> CheckDescriptionAlreadyExists(string description);
    }
}
