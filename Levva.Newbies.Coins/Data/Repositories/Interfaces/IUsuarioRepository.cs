using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Repositories.Interfaces {
    public interface IUsuarioRepository {

        void Create(Usuario usuario);
        Usuario Get(int Id);

        Usuario GetByEmailAndSenha(string email, string senha);
        List<Usuario> GetAll();
        void Update(Usuario usuario);
        void Delete(int Id);
    }
}
