using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Nuclear.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NuclearContext>
    {
        public NuclearContext GetDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.Development.json", true)
                .Build();

            var builder = new DbContextOptionsBuilder<NuclearContext>();
            builder.UseNpgsql(configuration.GetConnectionString("Database"));

            return new NuclearContext(builder.Options);
        }

        NuclearContext IDesignTimeDbContextFactory<NuclearContext>.CreateDbContext(string[] args)
        {
            return GetDbContext();
        }
    }
}
