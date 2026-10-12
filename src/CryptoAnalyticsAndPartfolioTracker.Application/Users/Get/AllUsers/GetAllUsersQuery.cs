using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Users.Get
{
    public record GetAllUsersQuery(Guid UserId) : IRequest<IEnumerable<User>>;
}