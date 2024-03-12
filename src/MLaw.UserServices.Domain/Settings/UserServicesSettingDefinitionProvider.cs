using Volo.Abp.Settings;

namespace MLaw.UserServices.Settings;

public class UserServicesSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(UserServicesSettings.MySetting1));
    }
}
