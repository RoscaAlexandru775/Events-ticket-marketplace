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
    public class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.EventOrganizer).WithOne(b => b.OrganizerEvent).HasForeignKey<Event>(b => b.OrganizatorId).IsRequired(false);
            builder.Property(x => x.FullName).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
            builder.Property(x => x.Email).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
            builder.Property(x => x.Mobile).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
        }
    }
}
