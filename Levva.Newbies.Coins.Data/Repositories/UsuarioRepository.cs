using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Repositories {
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository {
        public UsuarioRepository(IContext context) : base(context) { }

        public Usuario GetByEmailAndSenha(string email, string senha) {
            return Context.Set<Usuario>().First(x => x.Email.Equals(email));
        }

        
    }
}
