using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB.Configurations
{
    public class PartfolioConfiguration : IEntityTypeConfiguration<Partfolio>
    {
        public void Configure(EntityTypeBuilder<Partfolio> builder)
        {
            builder.HasKey(p => p.PartfolioId);
            builder.HasIndex(p => p.UserId);
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.Property(p => p.Operation);
            builder.Property(p => p.Date);
            builder.Property(p => p.Coin);
            builder.Property(p => p.Note);
            builder.Property(p => p.PlatformTitle);
        }
    }
}