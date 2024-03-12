using Volo.Abp.Modularity;

namespace MLaw.UserServices;

[DependsOn(
    typeof(UserServicesApplicationModule),
    typeof(UserServicesDomainTestModule)
    )]
public class UserServicesApplicationTestModule : AbpModule
{

}
