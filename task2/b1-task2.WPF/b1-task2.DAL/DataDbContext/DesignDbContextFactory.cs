using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace b1_task2.DAL.DataDbContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<b1TaskDbContext>
    {
        public b1TaskDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<b1TaskDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("MyDbConnection"));

            return new b1TaskDbContext(builder.Options);
        }
    }
}
