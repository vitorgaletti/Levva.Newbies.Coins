using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Services;

namespace Levva.Newbies.Coins.Business.Interfaces {
    public interface ICategoryService {
        Task<ResultService<CategoryDto>> Create(CategoryDto category);
        CategoryDto Get(Guid Id);
        Task<List<CategoryDto>> GetAll();
        void Update(CategoryDto category);
        void Delete(Guid Id);
    }
}
