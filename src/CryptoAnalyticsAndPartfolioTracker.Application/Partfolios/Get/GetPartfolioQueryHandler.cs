using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Repositories;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using MediatR;
using MediatR.Pipeline;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Partfolios.Get
{
    public class GetPartfolioQueryHandler : IRequestHandler<GetPartfolioQuery, IEnumerable<Partfolio>?>
    {
        private readonly IPartfolioRepository _partfolioRepository;

        public GetPartfolioQueryHandler(IPartfolioRepository partfolioRepository)
        {
            _partfolioRepository = partfolioRepository;
        }
        public async Task<IEnumerable<Partfolio>?> Handle(GetPartfolioQuery request, CancellationToken cancellationToken)
        {
            var partfolios = await _partfolioRepository.GetAllByUserIdAsync(request.UserId, cancellationToken);

            return partfolios;
        }
    }
}