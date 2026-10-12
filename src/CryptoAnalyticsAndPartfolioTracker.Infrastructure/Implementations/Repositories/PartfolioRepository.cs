using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Repositories;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.Repositories
{
    public class PartfolioRepository : IPartfolioRepository
    {
        private readonly CryptoContext _context;

        public PartfolioRepository(CryptoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(IEnumerable<Partfolio> partfolios, CancellationToken cancellationToken)
        {
            await _context.Partfolios.AddRangeAsync(partfolios, cancellationToken);
        }

        public async Task<IEnumerable<Partfolio>?> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var partfolios = await _context.Partfolios.Where(p => p.UserId == userId).ToListAsync();
            return partfolios;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
        }
    }
}