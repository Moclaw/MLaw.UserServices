using MLaw.UserServices.DTOs;
using MLaw.UserServices.Entities;

namespace MLaw.UserServices.IRepositories
{
    public interface IUserRepository : IBaseRepository<Users, UsersDTO>
    {
    }
}
