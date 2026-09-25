using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.API.DTOs.Requests.Login
{
    public record LoginRequest(string Email, string Password);
}