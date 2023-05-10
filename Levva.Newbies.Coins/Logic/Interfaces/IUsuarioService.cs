using Levva.Newbies.Coins.Logic.Dtos;

namespace Levva.Newbies.Coins.Logic.Interfaces {
    public interface IUsuarioService {
        void Create(UsuarioDto usuario);
        UsuarioDto Get(int Id);
        List<UsuarioDto> GetAll();
        void Update(UsuarioDto usuario);
        void Delete(int Id);    
    }
}
