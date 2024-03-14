using GIIS.KafkaServices.EntityFrameworkCore.DbContext.Implements;
using Microsoft.Extensions.DependencyInjection;
using MLaw.UserServices.Settings;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GIIS.KafkaServices.EntityFrameworkCore;

[DependsOn(
    typeof(UserServicesDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class UserServicesEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _ = context.Services.AddAbpDbContext<UserServicesDbContext>(o => { });
    }
}
