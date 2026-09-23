using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string HashPassword { get; private set; }

        public User(string userName, string email, string hashPasswrod)
        {
            UserName = userName;
            if (!email.Contains('@'))
                throw new InvalidOperationException("Invalid Email.");
            Email = email;
            HashPassword = hashPasswrod;
        }
    }
}