using Microsoft.EntityFrameworkCore;
using MLaw.UserServices.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static MLaw.UserServices.Settings.UserServicesConsts.ConnectionStringName;

namespace GIIS.KafkaServices.EntityFrameworkCore.DbContext.Implements;

[ConnectionStringName(Default)]
public class UserServicesDbContext : AbpDbContext<UserServicesDbContext>, IUserServicesDbContext
{
    public UserServicesDbContext(DbContextOptions<UserServicesDbContext> options) : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<RolesUsers> RolesUsers { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<LoginHistories> LoginHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureKafkServices();
    }
}
