using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<User> GetUserAsync(Guid UserId, CancellationToken cancellationToken = default);
        Task CreateAsync(User user, CancellationToken cancellationToken = default);
        Task UpdateAsync(User user, CancellationToken cancellationToken = default);
        Task RemoveAsync(User user, CancellationToken cancellationToken = default);
    }
}