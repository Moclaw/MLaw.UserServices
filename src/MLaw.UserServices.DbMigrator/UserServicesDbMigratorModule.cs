using MLaw.UserServices.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MLaw.UserServices.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UserServicesEntityFrameworkCoreModule),
    typeof(UserServicesApplicationContractsModule)
    )]
public class UserServicesDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
