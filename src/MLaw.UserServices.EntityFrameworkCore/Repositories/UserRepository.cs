using GIIS.KafkaServices.EntityFrameworkCore.DbContext;
using Microsoft.Extensions.Logging;
using MLaw.UserServices.DTOs;
using MLaw.UserServices.Entities;
using MLaw.UserServices.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLaw.UserServices.Repositories
{
    public class UserRepository : BaseRepository<Users, UsersDTO>, IUserRepository
    {
        public UserRepository(IUserServicesDbContext context, ILogger<BaseRepository<Users, UsersDTO>> logger) : base(context, logger)
        {
        }
    }
}
