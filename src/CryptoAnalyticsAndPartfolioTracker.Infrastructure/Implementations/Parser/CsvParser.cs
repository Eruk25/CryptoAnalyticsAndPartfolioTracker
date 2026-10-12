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

        public IDocument Parse(Stream stream)
        {
            var reader = new StreamReader(stream);
            var csv = new CsvReader(reader, true);

            var headers = csv.GetFieldHeaders();

            return new CsvDocument(headers, ReadRows(csv, headers, reader));
        }

        private static IEnumerable<DataRow> ReadRows(CsvReader csv, string[] headers, StreamReader reader)
        {
            using (reader)
            using (csv)
            {
                while (csv.ReadNextRecord())
                {
                    var values = new Dictionary<string, string>();

                    foreach (var header in headers)
                    {
                        values[header] = csv[header] ?? string.Empty;
                    }

                    yield return new DataRow
                    {
                        Values = values
                    };
                }
            }
        }
    }
}