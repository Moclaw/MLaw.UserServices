using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace MLaw.UserServices;

[DependsOn(
    typeof(UserServicesDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class UserServicesApplicationContractsModule : AbpModule
{
}
