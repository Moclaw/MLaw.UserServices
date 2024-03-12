using Localization.Resources.AbpUi;
using MLaw.UserServices.Localization;
using Volo.Abp.Account;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace MLaw.UserServices;

[DependsOn(
    typeof(UserServicesApplicationContractsModule),
    typeof(AbpAccountHttpApiModule)
    )]
public class UserServicesHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<UserServicesResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
