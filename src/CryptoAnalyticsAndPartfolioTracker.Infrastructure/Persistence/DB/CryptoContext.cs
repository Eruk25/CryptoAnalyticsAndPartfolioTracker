using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB
{
    public class CryptoContext(DbContextOptions<CryptoContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}