using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser
{
    public interface IDocument
    {
        IReadOnlyList<string> Headers { get; }
        IEnumerable<DataRow> Rows { get; }
    }
}