using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAnalyticsAndPartfolioTracker.Domain.Entities
{
    public class Partfolio
    {
        public Guid PartfolioId { get; private set; }
        public Guid UserId { get; private set; }
        public User? User { get; private set; }
        public string Operation { get; private set; }
        public string Coin { get; private set; }

        public Partfolio(Guid userId, string operation, string coin)
        {
            UserId = userId;
            Operation = operation;
            Coin = coin;
        }
    }
}