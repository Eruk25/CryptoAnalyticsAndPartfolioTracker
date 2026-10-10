using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser
{
    public interface IParser
    {
        bool IsParse(string contentType);
        Task<CsvDocument> ParseAsync(Stream stream);
    }
}