using Xunit;

namespace MLaw.UserServices.EntityFrameworkCore;

[CollectionDefinition(UserServicesTestConsts.CollectionDefinitionName)]
public class UserServicesEntityFrameworkCoreCollection : ICollectionFixture<UserServicesEntityFrameworkCoreFixture>
{

}
