using Volo.Abp.Modularity;

namespace MLaw.UserServices;

[DependsOn(
    typeof(UserServicesDomainSharedModule)
)]
public class UserServicesDomainModule : AbpModule
{

}
