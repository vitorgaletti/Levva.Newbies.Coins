using Levva.Newbies.Coins.Data.Repositories.Interfaces;
using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Repositories {
    public class UsuarioRepository : IUsuarioRepository {

        private readonly Context _context;
        public UsuarioRepository(Context context) {
            _context = context;
        }

        public void Create(UsuarioDto usuario) {
            _context.Usuario.Add(usuario);
        }

        public UsuarioDto Get(int Id) {
            return  _context.Usuario.Find(Id);
        }

        public List<UsuarioDto> GetAll() {
            return _context.Usuario.ToList();
        }

        public void Update(UsuarioDto usuario) {
            _context.Usuario.Update(usuario);
        }

        public void Delete(int Id) {
            var usuario = _context.Usuario.Find(Id);
            _context.Usuario.Remove(usuario);
        }
    }
}
