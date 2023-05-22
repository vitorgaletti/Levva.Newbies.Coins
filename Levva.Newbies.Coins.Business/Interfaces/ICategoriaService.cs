using Levva.Newbies.Coins.Business.Dtos;

namespace Levva.Newbies.Coins.Business.Interfaces {
    public interface ICategoriaService {
        void Create(CategoriaDto categoria);
        CategoriaDto Get(int Id);
        List<CategoriaDto> GetAll();
        void Update(CategoriaDto categoria);
        void Delete(int Id);
    }
}
