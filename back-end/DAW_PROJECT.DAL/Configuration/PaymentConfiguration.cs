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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreditPay).HasColumnType("int");
            builder.Property(x => x.FullName).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
            builder.Property(x => x.CardNumber).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
            builder.Property(x => x.CVV).HasColumnType("int");
            builder.Property(x => x.ExpireDate).HasColumnType("nvarchar(100)")
               .HasMaxLength(100);
        }
    }
}
