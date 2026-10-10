using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Implementations.Parser
{
    public class ParserSolver : IParserSolver
    {
        private readonly IEnumerable<IParser> _parsers;

        public ParserSolver(IEnumerable<IParser> parsers)
        {
            _parsers = parsers;
        }
        public IParser Solve(string contentType)
        {
            var parser = _parsers.FirstOrDefault(p => p.IsParse(contentType));

            if (parser is null)
                throw new NotSupportedException($"Unsupported content type: {contentType}");

            return parser;
        }
    }
}