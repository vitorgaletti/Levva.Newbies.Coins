using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Levva.Newbies.Coins.Data.Configuration {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(150);
            builder.Property(c => c.Email).HasMaxLength(150);
            builder.Property(c => c.Password).HasMaxLength(500);

            builder.HasMany(c => c.Transactions)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.Id);
        }
    }
}
