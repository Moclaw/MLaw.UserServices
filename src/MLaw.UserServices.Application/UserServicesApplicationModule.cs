using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace MLaw.UserServices;

[DependsOn(
    typeof(UserServicesDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(UserServicesApplicationContractsModule)
    )]
public class UserServicesApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<UserServicesApplicationModule>();
        });
    }
}
