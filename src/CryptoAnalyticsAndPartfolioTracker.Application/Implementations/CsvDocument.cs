using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser
{
    public class CsvDocument : IDocument
    {
        public IReadOnlyList<string> Headers { get; }
        public IEnumerable<DataRow> Rows { get; }

        public CsvDocument(IReadOnlyList<string> headers, IEnumerable<DataRow> rows)
        {
            Headers = headers;
            Rows = rows;
        }
    }
}