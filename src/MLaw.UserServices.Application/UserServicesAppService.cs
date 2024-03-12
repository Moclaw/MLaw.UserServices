using MLaw.UserServices.Localization;
using Volo.Abp.Application.Services;

namespace MLaw.UserServices;

/* Inherit your application services from this class.
 */
public abstract class UserServicesAppService : ApplicationService
{
    protected UserServicesAppService()
    {
        LocalizationResource = typeof(UserServicesResource);
    }
}
