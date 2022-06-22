
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
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NeighborhoodId).IsRequired();
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.NeighborhoodFK).WithMany(p => p.Streets).HasForeignKey(p => p.NeighborhoodId);

        }
    }
}
