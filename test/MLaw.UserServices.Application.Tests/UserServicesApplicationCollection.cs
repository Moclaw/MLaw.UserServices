using MLaw.UserServices.EntityFrameworkCore;
using Xunit;

namespace MLaw.UserServices;

[CollectionDefinition(UserServicesTestConsts.CollectionDefinitionName)]
public class UserServicesApplicationCollection : UserServicesEntityFrameworkCoreCollectionFixtureBase
{

}
