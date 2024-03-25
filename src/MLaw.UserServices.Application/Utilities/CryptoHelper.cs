using System.Security.Cryptography;
using System.Text;
using System;

namespace MLaw.UserServices.Utilities
{
    public static class CryptoHelper
    {
        public static string HashPassword(string password, string scecretKey)
        {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(scecretKey));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(computedHash);
        }

        public static bool VerifyPassword(string password, string passwordHash, string secretKey)
        {
            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(secretKey));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(computedHash) == passwordHash;
        }
    }
}