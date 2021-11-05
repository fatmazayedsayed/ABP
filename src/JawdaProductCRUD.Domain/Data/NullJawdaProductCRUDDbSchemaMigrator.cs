using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace JawdaProductCRUD.Data
{
    /* This is used if database provider does't define
     * IJawdaProductCRUDDbSchemaMigrator implementation.
     */
    public class NullJawdaProductCRUDDbSchemaMigrator : IJawdaProductCRUDDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}