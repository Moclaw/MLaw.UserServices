using MLaw.UserServices.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MLaw.UserServices.Permissions;

public class UserServicesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UserServicesPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(UserServicesPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UserServicesResource>(name);
    }
}
