using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration
{
    public class ReviewsConfigurations : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
           builder.HasKey(r=>r.Id);

            builder.Property(r => r.FullName)
                 .IsRequired() .HasMaxLength(200);

            builder.Property(r => r.Rate)
             .IsRequired().HasAnnotation("Range", "1,5");// Ensures the rate is between 1 and 5

            builder.Property(r => r.Description)
             .IsRequired().HasMaxLength(1000);

            // Foreign key configuration
            builder.HasOne(r => r.Trip)
             .WithMany(t => t.Reviews)
             .HasForeignKey(r => r.TripId);
        }
    }
}
