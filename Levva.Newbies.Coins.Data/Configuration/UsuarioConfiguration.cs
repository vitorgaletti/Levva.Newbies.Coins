using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Levva.Newbies.Coins.Data.Configuration {
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario> {
        public void Configure(EntityTypeBuilder<Usuario> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(150);
            builder.Property(c => c.Email).HasMaxLength(150);
            builder.Property(c => c.Senha).HasMaxLength(500);
        }
    }
}
