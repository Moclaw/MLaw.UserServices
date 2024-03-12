using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static MLaw.UserServices.UserServicesConsts.ConnectionStringName;

namespace GIIS.KafkaServices.EntityFrameworkCore.DbContext.Implements;

[ConnectionStringName(Default)]
public class UserServicesDbContext : AbpDbContext<UserServicesDbContext>, IUserServicesDbContext
{
    public UserServicesDbContext(DbContextOptions<UserServicesDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureKafkServices();
    }
}
