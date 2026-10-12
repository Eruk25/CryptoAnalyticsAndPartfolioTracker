using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser
{
    public sealed class DataRow
    {
        public IReadOnlyDictionary<string, string> Values { get; init; }
            = new Dictionary<string, string>();
    }
}