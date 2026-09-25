using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.API.DTOs.Requests.Register
{
    public record RegisterRequest(string UserName, string Email, string Password);
}