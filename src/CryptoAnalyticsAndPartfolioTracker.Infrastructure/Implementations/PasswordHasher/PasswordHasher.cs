using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.PasswordHasher;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHashed;
        }

        public bool VerifyPassword(string password, string hashPassword)
        {
            var verified = BCrypt.Net.BCrypt.Verify(password, hashPassword);

            return verified;
        }
    }
}