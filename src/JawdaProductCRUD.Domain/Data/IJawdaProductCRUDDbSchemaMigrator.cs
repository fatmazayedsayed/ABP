using System.Threading.Tasks;

namespace JawdaProductCRUD.Data
{
    public interface IJawdaProductCRUDDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
