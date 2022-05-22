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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.OrganizerEvent).WithOne(b => b.EventOrganizer).HasForeignKey<Organizer>(b => b.Id).IsRequired(false);
          
            builder.Property(x => x.Denumire).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
            builder.Property(x => x.ZiDesfasurare).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
          
            builder.Property(x => x.Pret).HasColumnType("int");
            builder.Property(x => x.NumarBilete).HasColumnType("int");
            builder.Property(x => x.Categorie).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
            builder.Property(x => x.OrganizatorId).HasColumnType("int");
        }
    }
}
