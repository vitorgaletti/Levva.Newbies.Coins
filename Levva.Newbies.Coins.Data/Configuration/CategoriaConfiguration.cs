using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Levva.Newbies.Coins.Data.Configuration {
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria> {
        public void Configure(EntityTypeBuilder<Categoria> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).HasMaxLength(50);
        }
    }
}
