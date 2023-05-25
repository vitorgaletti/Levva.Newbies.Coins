using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Levva.Newbies.Coins.Data.Configuration {
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao> {
        public void Configure(EntityTypeBuilder<Transacao> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).HasMaxLength(50);
            builder.Property(c => c.Valor).HasPrecision(6, 2);
            builder.Property(c => c.Data);
            builder.Property(c => c.Tipo);

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Transacoes)
                .HasForeignKey(x => x.CategoriaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Transacoes)
                .HasForeignKey(x => x.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
