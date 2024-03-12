using MLaw.UserServices.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MLaw.UserServices;

/* Inherit your controllers from this class.
 */
public abstract class UserServicesController : AbpControllerBase
{
    protected UserServicesController()
    {
        LocalizationResource = typeof(UserServicesResource);
    }
}
