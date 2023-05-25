using Levva.Newbies.Coins.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Levva.Newbies.Coins.Data {
    public class Context : DbContext, IContext {
        public Context(DbContextOptions<Context> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new TransacaoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges() {
            return base.SaveChanges();
        }
    }
}
