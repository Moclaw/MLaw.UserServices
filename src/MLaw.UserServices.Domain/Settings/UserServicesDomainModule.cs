using Volo.Abp.Modularity;

namespace MLaw.UserServices.Settings;

[DependsOn(
    typeof(UserServicesDomainSharedModule)
)]
public class UserServicesDomainModule : AbpModule
{

}
