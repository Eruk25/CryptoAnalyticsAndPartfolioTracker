using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claims)
        {
            var userId = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                throw new NullReferenceException("User was not found");

            return Guid.Parse(userId);
        }
    }
}