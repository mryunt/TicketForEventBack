
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
    public class OpenAddressConfiguration : IEntityTypeConfiguration<OpenAddress>
    {
        public void Configure(EntityTypeBuilder<OpenAddress> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CountryId).IsRequired();
            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.TownshipId).IsRequired();
            builder.Property(p => p.NeighborhoodId).IsRequired();
            builder.Property(p => p.StreetId).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasOne(p => p.CountryFK).WithMany(p => p.OpenAddresses).HasForeignKey(p => p.CountryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.CityFK).WithMany(p => p.OpenAddresses).HasForeignKey(p => p.CityId);
            builder.HasOne(p => p.TownshipFK).WithMany(p => p.OpenAddresses).HasForeignKey(p => p.TownshipId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.NeighborhoodFK).WithMany(p => p.OpenAddresses).HasForeignKey(p => p.NeighborhoodId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.StreetFK).WithMany(p => p.OpenAddresses).HasForeignKey(p => p.StreetId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
