using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levva.Newbies.Coins.Data {
    public class Context : DbContext {

        public DbSet<UsuarioDto> Usuario { get; set; }
        public DbSet<TransacaoDto> Transacao { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) {

        }
    }
}
