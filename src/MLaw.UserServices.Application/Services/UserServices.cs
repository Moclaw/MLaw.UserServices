using AutoMapper.Internal.Mappers;
using MLaw.UserServices.Application.Contracts.IServices;
using MLaw.UserServices.Application.Contracts.Requests;
using MLaw.UserServices.DTOs;
using MLaw.UserServices.Entities;
using MLaw.UserServices.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLaw.UserServices.Services
{
    public class UserServices : UserServicesAppService, IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(
                IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }
        public async ValueTask<UserRequest> CreateUserRequest(UserRequest request)
        {
            try
            {
                var user = ObjectMapper.Map<UserRequest, Users>(request);
                return ObjectMapper.Map<Users, UserRequest>(await _userRepository.InsertAsync(user));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ValueTask<UserRequest> GetUserRequest(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserRequest> UpdateUserRequest(UserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
