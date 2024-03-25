using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLaw.UserServices.Entities
{
    [Table("RefreshTokens")]
    public sealed class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
