using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MLaw.UserServices;

[Dependency(ReplaceServices = true)]
public class UserServicesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UserServices";
}
