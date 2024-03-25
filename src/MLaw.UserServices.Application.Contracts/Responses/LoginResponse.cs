using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLaw.UserServices.Application.Contracts.Responses
{
    public sealed record LoginResponse
    {
        public string Token { get; init; }
        public string RefreshToken { get; init; }
    }
}
