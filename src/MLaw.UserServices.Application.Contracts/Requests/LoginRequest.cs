using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLaw.UserServices.Application.Contracts.Requests
{
    public sealed record LoginRequest
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public bool  IsRemember { get; init; }
    }
}
