using Microsoft.EntityFrameworkCore;
using static Volo.Abp.Check;

namespace GIIS.KafkaServices.EntityFrameworkCore
{
    public static class UserServicesDbContextCreatingExtentions
    {
        public static void ConfigureUserServices(this ModelBuilder builder) => NotNull(builder, nameof(builder));
    }
}
