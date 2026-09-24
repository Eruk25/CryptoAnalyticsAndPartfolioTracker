using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.JwtGenerator
{
    public class AuthOptions
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public TimeSpan Expires { get; set; }
        public string SecretKey { get; set; } = default!;
    }
}