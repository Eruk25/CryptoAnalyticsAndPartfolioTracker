using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser
{
    public interface IImporter
    {
        bool IsHandle(IDocument document);
        Task ImportAsync(IDocument document, Guid userId, CancellationToken cancellationToken = default);
    }
}