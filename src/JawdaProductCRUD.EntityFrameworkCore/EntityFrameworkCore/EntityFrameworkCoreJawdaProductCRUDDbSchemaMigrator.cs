using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JawdaProductCRUD.Data;
using Volo.Abp.DependencyInjection;

namespace JawdaProductCRUD.EntityFrameworkCore
{
    public class EntityFrameworkCoreJawdaProductCRUDDbSchemaMigrator
        : IJawdaProductCRUDDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreJawdaProductCRUDDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the JawdaProductCRUDDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<JawdaProductCRUDDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
