using MLaw.UserServices.DTOs;
using MLaw.UserServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLaw.UserServices.IRepositories
{
    public interface IUserRepository : IBaseRepository<Users, UsersDTO>
    {
    }
}
