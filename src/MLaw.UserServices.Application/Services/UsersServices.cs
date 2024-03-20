using Microsoft.Extensions.Logging;
using MLaw.UserServices.Application.Contracts.Requests;
using MLaw.UserServices.Application.Contracts.Responses;
using MLaw.UserServices.DTOs;
using MLaw.UserServices.Entities;

namespace MLaw.UserServices.Services
{
    public class UsersServices : BaseServices<UsersRequest, UsersResponse, Users, UsersDTO>
    {
        public UsersServices(IBaseRepository<Users, UsersDTO> baseRepository, ILogger<BaseServices<UsersRequest, UsersResponse, Users, UsersDTO>> logger) : base(baseRepository, logger)
        {
        }
    }
}
