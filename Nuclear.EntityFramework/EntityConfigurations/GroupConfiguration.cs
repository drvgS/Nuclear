﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclear.EntityFramework.Models;

namespace Nuclear.EntityFramework.EntityConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).HasMaxLength(64);

            builder.HasMany(g => g.Accounts)
                .WithMany(a => a.Groups);

            builder.HasMany(g => g.Categories)
                .WithMany(c => c.Groups);
        }
    }
}
