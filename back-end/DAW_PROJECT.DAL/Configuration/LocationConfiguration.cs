using DAW_PROJECT.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.City).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
            builder.Property(x => x.Province).HasColumnType("nvarchar(100)")
              .HasMaxLength(100);
            builder.Property(x => x.Zipcode).HasColumnType("nvarchar(100)")
             .HasMaxLength(100);
            builder.Property(x => x.Country).HasColumnType("nvarchar(100)")
             .HasMaxLength(100);
            builder.Property(x => x.Address).HasColumnType("nvarchar(100)")
             .HasMaxLength(100);
           
        }
    }
}
