using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration
{
    public class TripsConfiguration : IEntityTypeConfiguration<Trips>
    {
        public void Configure(EntityTypeBuilder<Trips> builder)
        {
           
            builder.HasKey(t => t.Id);  //Primary Key
            builder.Property(t=>t.Title).IsRequired();
            builder.Property(t=>t.Price).HasColumnName("Price").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(t=>t.StartTripe).HasColumnName("StartTripe").HasColumnType("datetime").IsRequired(false);
            builder.Property(t => t.EndTripe).HasColumnName("EndTripe").HasColumnType("datetime").IsRequired(false);

        }
    }
}
