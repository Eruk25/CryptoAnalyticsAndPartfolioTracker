using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }

        private User() { }

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