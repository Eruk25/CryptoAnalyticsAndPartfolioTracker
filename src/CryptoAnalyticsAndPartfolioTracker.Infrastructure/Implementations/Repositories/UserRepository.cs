using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CryptoContext _context;

        public UserRepository(CryptoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(user, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await _context.Users.ToListAsync(cancellationToken);
            return users;
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FindAsync(new object[] { email }, cancellationToken);
            return user;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FindAsync(new object[] { userId }, cancellationToken);
            return user;
        }

        public async Task RemoveAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Remove(user);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Update(user);
        }
    }
}