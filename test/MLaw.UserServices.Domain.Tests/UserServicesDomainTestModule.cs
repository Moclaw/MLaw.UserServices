using MLaw.UserServices.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MLaw.UserServices;

[DependsOn(
    typeof(UserServicesEntityFrameworkCoreTestModule)
    )]
public class UserServicesDomainTestModule : AbpModule
{

}
