using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.DAL.Context
{
    public class TicketForEventDbContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B5VF1VT;Database=FirstTry;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Township> Townships { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<OpenAddress> OpenAddresses { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SalonSeat> SalonSeats { get; set; }
    }
}
