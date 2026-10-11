using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB
{
    public class CryptoContextFactory : IDesignTimeDbContextFactory<CryptoContext>
    {
        public CryptoContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../CryptoAnalyticsAndPartfolioTracker.API");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionBuilder = new DbContextOptionsBuilder<CryptoContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new CryptoContext(optionBuilder.Options);
        }
    }
}