using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.DAL.Configuration
{
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.OpenAddresId).IsRequired();

            builder.HasOne(p => p.OpenAddressFK).WithMany(p => p.Salons).HasForeignKey(p => p.OpenAddresId);
        }
    }
}
