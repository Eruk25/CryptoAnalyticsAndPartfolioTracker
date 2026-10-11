using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Repositories;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.Repositories
{
    public class PartfolioRepository : IPartfolioRepository
    {
        private readonly CryptoContext _context;

        public PartfolioRepository(CryptoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Partfolio partfolio, CancellationToken cancellationToken)
        {
            await _context.Partfolios.AddAsync(partfolio, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Partfolio?> GetByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var partfolio = await _context.Partfolios.FindAsync([userId], cancellationToken);

            return partfolio;
        }
    }
}