using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB
{
    public class CryptoContext(DbContextOptions<CryptoContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}