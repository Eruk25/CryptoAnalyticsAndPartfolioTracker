using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Repositories
{
    public interface IPartfolioRepository
    {
        Task<IEnumerable<Partfolio>?> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task CreateAsync(IEnumerable<Partfolio> partfolios, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}