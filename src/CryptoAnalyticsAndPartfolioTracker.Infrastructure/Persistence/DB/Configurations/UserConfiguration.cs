using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAnalyticsAndPartfolioTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Persistence.DB.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserName)
                .IsRequired(true);
            builder.HasIndex(u => u.Email)
                .IsUnique(true);

            builder.Property(u => u.HashPassword)
                .IsRequired(true);

        }
    }
}