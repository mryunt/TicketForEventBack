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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.EventTypeId).IsRequired();
            builder.Property(e => e.SalonId).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.Image).IsRequired();
            builder.Property(e => e.Explanation).IsRequired();

            builder.HasOne(e => e.EventTypeFK).WithMany(e => e.Events).HasForeignKey(e => e.EventTypeId);
            builder.HasOne(e => e.SalonFK).WithMany(e => e.Events).HasForeignKey(e => e.SalonId);
        }
    }
}
