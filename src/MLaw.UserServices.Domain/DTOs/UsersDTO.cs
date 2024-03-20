﻿namespace MLaw.UserServices.DTOs
{
    public record UsersDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
