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
        public DateTime Date { get; set; }
        public string Coin { get; set; }
        public string? Note { get; set; }
        public string PlatformTitle { get; set; }

        public Partfolio(Guid userId, DateTime date, string operation, string coin, string? note, string platformTitle)
        {
            UserId = userId;
            Date = date;
            Operation = operation;
            Coin = coin;
            Note = note;
            PlatformTitle = platformTitle;
        }
    }
}