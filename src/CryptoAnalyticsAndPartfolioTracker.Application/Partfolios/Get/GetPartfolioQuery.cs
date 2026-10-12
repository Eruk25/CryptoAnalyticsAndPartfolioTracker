using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Partfolios.Get
{
    public record GetPartfolioQuery(Guid UserId) : IRequest<IEnumerable<Partfolio>?>;
}