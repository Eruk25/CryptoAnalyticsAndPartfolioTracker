using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser
{
    public class CsvRow
    {
        public IReadOnlyDictionary<string, string> Values { get; init; }
            = new Dictionary<string, string>();
    }
}