using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser;
using LumenWorks.Framework.IO.Csv;
using Microsoft.EntityFrameworkCore.Query;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.Parser
{
    public class CsvParser : IParser
    {
        public IReadOnlyCollection<string> types =
        [
            "text/csv",
            "text/csv; charset=utf-8",
            "multipart/mixed"
        ];
        public bool IsParse(string contentType)
            => types.Contains(contentType);

        public Task<CsvDocument> ParseAsync(Stream stream)
        {
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, true);

            var headers = csv.GetFieldHeaders();
            var rows = new List<CsvRow>();

            while (csv.ReadNextRecord())
            {
                var row = new Dictionary<string, string>();
                foreach (var header in headers)
                {
                    row[header] = csv[header] ?? string.Empty;
                }

                rows.Add(new CsvRow
                {
                    Values = row
                });
            }
            var document = new CsvDocument()
            {
                Headers = headers,
                Rows = rows
            };

            return Task.FromResult(document);
        }
    }
}