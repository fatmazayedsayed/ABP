using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JawdaProductCRUD.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class JawdaProductCRUDDbContextFactory : IDesignTimeDbContextFactory<JawdaProductCRUDDbContext>
    {
        public JawdaProductCRUDDbContext CreateDbContext(string[] args)
        {
            JawdaProductCRUDEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<JawdaProductCRUDDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new JawdaProductCRUDDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../JawdaProductCRUD.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
