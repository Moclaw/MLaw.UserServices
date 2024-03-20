using MLaw.UserServices.Application.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MLaw.UserServices.Application.Contracts.IServices
{
    public interface IUserServices : IApplicationService
    {
        ValueTask<UserRequest> CreateUserRequest(UserRequest request);

        ValueTask<UserRequest> UpdateUserRequest(UserRequest request);

        ValueTask<UserRequest> GetUserRequest(int id);
      
    }
}
