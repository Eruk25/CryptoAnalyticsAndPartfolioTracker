using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.JwtGenerator
{
    public interface IJwtGenerator
    {
        string Generate(User user);
    }
}