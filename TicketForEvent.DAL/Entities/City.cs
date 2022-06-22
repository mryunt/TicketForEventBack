using AppCore.Entity;
using System.Collections.Generic;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.DAL.Entities
{
    public class City : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public Country CountryFK { get; set; }
        public ICollection<Township> Townships { get; set; }
        
        public ICollection<OpenAddress> OpenAddresses { get; set; }
        public bool IsDeleted { get; set; }
    }
}
