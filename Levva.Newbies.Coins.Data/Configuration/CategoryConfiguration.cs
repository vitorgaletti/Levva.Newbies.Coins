using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Levva.Newbies.Coins.Data.Configuration {
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(50);

            builder.HasMany(c => c.Transactions)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.Id);
        }
    }
}
