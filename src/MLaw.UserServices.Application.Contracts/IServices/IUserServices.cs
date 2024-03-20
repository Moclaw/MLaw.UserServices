using MLaw.UserServices.Application.Contracts.Requests;
using MLaw.UserServices.Application.Contracts.Responses;

namespace MLaw.UserServices.Application.Contracts.IServices
{
    public interface IUserServices : IBaseServices<UsersRequest, UsersResponse>
    {
    }
}
