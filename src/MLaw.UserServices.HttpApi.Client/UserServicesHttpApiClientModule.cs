using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace MLaw.UserServices;

[DependsOn(
    typeof(UserServicesApplicationContractsModule),
    typeof(AbpAccountHttpApiClientModule)
)]
public class UserServicesHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(UserServicesApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<UserServicesHttpApiClientModule>();
        });
    }
}
