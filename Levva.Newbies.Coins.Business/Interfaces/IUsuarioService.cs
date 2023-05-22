using Levva.Newbies.Coins.Business.Dtos;

namespace Levva.Newbies.Coins.Business.Interfaces {
    public interface IUsuarioService {
        void Create(UsuarioDto usuario);
        UsuarioDto Get(int Id);
        List<UsuarioDto> GetAll();
        void Update(UsuarioDto usuario);
        void Delete(int Id);
        LoginDto Login(LoginDto login);
    }
}
