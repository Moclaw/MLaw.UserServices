using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static MLaw.UserServices.UserServicesConsts.ConnectionStringName;

namespace GIIS.KafkaServices.EntityFrameworkCore.DbContext
{
    [ConnectionStringName(Default)]
    public interface IUserServicesDbContext : IEfCoreDbContext
    {
    }
}
