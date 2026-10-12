using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Repositories;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using Microsoft.Identity.Client.Extensibility;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.Parser
{
    public class BinanceImporter : IImporter
    {
        private readonly IPartfolioRepository _partfolioRepository;
        private const int BatchSize = 1000;

        public BinanceImporter(IPartfolioRepository partfolioRepository)
        {
            _partfolioRepository = partfolioRepository;
        }

        public async Task ImportAsync(IDocument document, Guid userId, CancellationToken cancellationToken)
        {
            if (document is not CsvDocument csvDocument)
                throw new ArgumentException("Unsuported document type");


            var batch = new List<Partfolio>();
            foreach (var row in csvDocument.Rows)
            {
                cancellationToken.ThrowIfCancellationRequested();

                batch.Add(new Partfolio(
                    userId,
                    DateTime.Parse(row.Values["Время"]),
                    row.Values["Операция"],
                    row.Values["Коин"],
                    row.Values["Примечание"],
                    "Binance"));

                if (batch.Count >= BatchSize)
                {
                    await _partfolioRepository.CreateAsync(batch, cancellationToken);
                    await _partfolioRepository.SaveChangesAsync(cancellationToken);

                    batch.Clear();
                }
            }

            if (batch.Count > 0)
            {
                await _partfolioRepository.CreateAsync(batch, cancellationToken);
                await _partfolioRepository.SaveChangesAsync(cancellationToken);
            }
        }

        public bool IsHandle(IDocument document)
        {
            return true;
        }
    }
}