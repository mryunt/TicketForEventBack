
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
    public class TownshipConfiguration : IEntityTypeConfiguration<Township>
    {
        public void Configure(EntityTypeBuilder<Township> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.CityFK).WithMany(p => p.Townships).HasForeignKey(p => p.CityId);
        }
    }
}
