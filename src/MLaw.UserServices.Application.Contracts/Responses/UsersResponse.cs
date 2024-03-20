using System;

namespace MLaw.UserServices.Application.Contracts.Responses
{
    public sealed class UsersResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
