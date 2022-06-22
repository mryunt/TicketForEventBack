
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
    public class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
    {
        public void Configure(EntityTypeBuilder<Neighborhood> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TownshipId).IsRequired();
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.TownshipFK).WithMany(p => p.Neighborhoods).HasForeignKey(p => p.TownshipId);
        }
    }
}
