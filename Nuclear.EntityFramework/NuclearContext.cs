using System;
using Microsoft.EntityFrameworkCore;
using Nuclear.EntityFramework.EntityConfigurations;
using Nuclear.EntityFramework.Models;

namespace Nuclear.EntityFramework
{
    public class NuclearContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public NuclearContext() : base()
        { 
            
        }

        public NuclearContext(DbContextOptions<NuclearContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
