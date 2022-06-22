using AppCore.Entity;
using System.Collections;
using System.Collections.Generic;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.DAL.Entities
{
    public class OpenAddress : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country CountryFK { get; set; }
        public int CityId { get; set; }
        public City CityFK { get; set; }
        public int NeighborhoodId { get; set; }
        public Neighborhood NeighborhoodFK { get; set; }
        public int TownshipId { get; set; }
        public Township TownshipFK { get; set; }
        public int StreetId { get; set; }
        public Street StreetFK { get; set; }
        public ICollection<Salon> Salons { get; set; }
       
        public bool IsDeleted { get; set; }
    }
}
