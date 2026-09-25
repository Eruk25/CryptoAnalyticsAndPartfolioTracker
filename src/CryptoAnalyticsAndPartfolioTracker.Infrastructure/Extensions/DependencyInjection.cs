using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.JwtGenerator;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.PasswordHasher;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.JwtGenerator;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.PasswordHasher;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.Repositories;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            services.AddDbContext<CryptoContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}