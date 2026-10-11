using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Repositories
{
    public interface IPartfolioRepository
    {
        Task<Partfolio?> GetByUserId(Guid userId, CancellationToken cancellationToken = default);
        Task CreateAsync(Partfolio partfolio, CancellationToken cancellationToken = default);
    }
}