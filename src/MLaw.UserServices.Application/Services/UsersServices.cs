using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MLaw.UserServices.Application.Contracts.IServices;
using MLaw.UserServices.Application.Contracts.Requests;
using MLaw.UserServices.Application.Contracts.Responses;
using MLaw.UserServices.DTOs;
using MLaw.UserServices.Entities;
using MLaw.UserServices.IRepositories;
using static MLaw.UserServices.Utilities.TokenHelper;
using static MLaw.UserServices.Utilities.CryptoHelper;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using static MLaw.UserServices.UserServicesDomainErrorCodes;

namespace MLaw.UserServices.Services
{
    public class UsersServices : BaseServices<UsersRequest, UsersResponse, Users, UsersDTO>, IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UsersServices> _logger;
        private readonly string _secretKey;

        public UsersServices(IBaseRepository<Users, UsersDTO> baseRepository,
                             IUserRepository userRepository,
                             ILogger<UsersServices> logger,
                             IConfiguration configuration
        )
        : base(baseRepository, logger)
        {
            _userRepository = userRepository;
            _logger = logger;
            _secretKey = configuration["StringEncryption:DefaultPassPhrase"];
        }

        public async ValueTask<UsersResponse> CreateUserRequest(RegisterRequest request)
        {
            var user = await _userRepository.GetByKey(nameof(Users.Email), request.Email);
            if (user != null)
            {
                throw new BusinessException(CONFLICT).WithData(nameof(Users.PhoneNumber), request.Email);
            }

            user = await _userRepository.GetByKey(nameof(Users.PhoneNumber), request.PhoneNumber);
            if (user != null)
            {
                throw new BusinessException(CONFLICT).WithData(nameof(Users.PhoneNumber), request.PhoneNumber);
            }

            var ent = ObjectMapper.Map<RegisterRequest, Users>(request);

            ent.Password = HashPassword(request.Password, _secretKey);

            var result = await _userRepository.Add(ent) ?? throw new BusinessException(BAD_REQUEST);

            var token = GenerateToken(ObjectMapper.Map<Users, UsersRequest>(result));   

           






        }

        public ValueTask<UsersResponse> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<LoginResponse> LoginRequest(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
