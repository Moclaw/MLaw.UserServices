using Microsoft.EntityFrameworkCore;
using MLaw.UserServices.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using static MLaw.UserServices.Settings.UserServicesConsts.ConnectionStringName;

namespace GIIS.KafkaServices.EntityFrameworkCore.DbContext
{
    [ConnectionStringName(Default)]
    public interface IUserServicesDbContext : IEfCoreDbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesUsers> RolesUsers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<LoginHistories> LoginHistories { get; set; }
    }
}
