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
    public class SalonSeatConfiguration : IEntityTypeConfiguration<SalonSeat>
    {
        public void Configure(EntityTypeBuilder<SalonSeat> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.SalonId).IsRequired();
            builder.Property(p => p.SeatId).IsRequired();

            builder.HasOne(p => p.SalonFK).WithMany(p => p.SalonSeats).HasForeignKey(p => p.SalonId);
            builder.HasOne(p => p.SeatFK).WithMany(p => p.SalonSeats).HasForeignKey(p => p.SeatId);
        }
    }
}
