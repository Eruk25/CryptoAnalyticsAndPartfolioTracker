using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser
{
    public class CsvDocument : IDocument
    {
        public IReadOnlyList<string> Headers { get; init; } = [];
        public IReadOnlyList<CsvRow> Rows { get; init; } = [];
    }
}