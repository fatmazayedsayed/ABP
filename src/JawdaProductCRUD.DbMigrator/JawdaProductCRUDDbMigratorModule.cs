using JawdaProductCRUD.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace JawdaProductCRUD.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(JawdaProductCRUDEntityFrameworkCoreModule),
        typeof(JawdaProductCRUDApplicationContractsModule)
        )]
    public class JawdaProductCRUDDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
