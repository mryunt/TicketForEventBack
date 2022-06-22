
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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CountryID).IsRequired();
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.CountryFK).WithMany(p => p.Cities).HasForeignKey(p => p.CountryID);
        }
    }
}
