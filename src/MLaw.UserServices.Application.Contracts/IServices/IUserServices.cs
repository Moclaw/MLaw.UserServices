using MLaw.UserServices.Application.Contracts.Requests;
using MLaw.UserServices.Application.Contracts.Responses;
using System;
using System.Threading.Tasks;

namespace MLaw.UserServices.Application.Contracts.IServices
{
    public interface IUserServices : IBaseServices<UsersRequest, UsersResponse>
    {
        ValueTask<LoginResponse> LoginRequest(LoginRequest request);

        ValueTask<LoginResponse> CreateUserRequest(RegisterRequest request);

        ValueTask<UsersResponse> GetUser(Guid id);
    }
}
