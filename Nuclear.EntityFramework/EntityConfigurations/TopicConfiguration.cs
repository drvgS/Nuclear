using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclear.EntityFramework.Models;

namespace Nuclear.EntityFramework.EntityConfigurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(256);

            builder.HasOne(t => t.Category)
                .WithMany(c => c.Topics);

            builder.HasMany(t => t.Posts)
                .WithOne(p => p.Topic);
        }
    }
}
