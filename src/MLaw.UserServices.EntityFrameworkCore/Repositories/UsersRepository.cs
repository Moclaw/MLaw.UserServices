using GIIS.KafkaServices.EntityFrameworkCore.DbContext;
using Microsoft.Extensions.Logging;
using MLaw.UserServices.DTOs;
using MLaw.UserServices.Entities;
using MLaw.UserServices.IRepositories;

namespace MLaw.UserServices.Repositories
{
    public class UsersRepository : BaseRepository<Users, UsersDTO>, IUserRepository
    {
        public UsersRepository(IUserServicesDbContext context, ILogger<BaseRepository<Users, UsersDTO>> logger) : base(context, logger)
        {
        }
    }
}
