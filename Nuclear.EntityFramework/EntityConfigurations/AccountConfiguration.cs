using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclear.EntityFramework.Models;

namespace Nuclear.EntityFramework.EntityConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.AccountName).HasMaxLength(64);
            builder.Property(a => a.Password).HasMaxLength(256);
            builder.Property(a => a.Email).HasMaxLength(64);

            builder.HasMany(a => a.Groups)
                .WithMany(g => g.Accounts);
        }
    }
}
