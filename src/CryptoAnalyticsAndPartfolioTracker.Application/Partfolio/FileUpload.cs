using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Partfolio
{
    public record FileUpload(Stream Stream, string FileName, string ContentType);
}