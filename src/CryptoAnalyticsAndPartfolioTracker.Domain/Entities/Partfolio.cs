using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Domain.Entities
{
    public class Partfolio
    {
        public Guid PartfolioId { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string Operation { get; set; }
        public string Coin { get; set; }
        public string PlatformTitle { get; set; }

        public Partfolio(Guid userId, string operation, string coin, string platformTitle)
        {
            UserId = userId;
            Operation = operation;
            Coin = coin;
            PlatformTitle = platformTitle;
        }
    }
}