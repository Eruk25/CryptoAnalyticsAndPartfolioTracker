using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Application.Partfolios
{
    public record FileUpload(Stream Stream, string FileName, string ContentType);
}