using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Application.Abstractions.Parser;
using MediatR;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Partfolio.Import
{
    public record ImportCommand(Guid UserId, IEnumerable<FileUpload> Files) : IRequest;
}