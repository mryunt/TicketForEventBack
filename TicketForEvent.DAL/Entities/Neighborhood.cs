using AppCore.Entity;
using System.Collections.Generic;

namespace TicketForEvent.DAL.Entities
{
    public class Neighborhood : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TownshipId { get; set; }
        public Township TownshipFK { get; set; }
        public ICollection<Street> Streets { get; set; }
        public ICollection<OpenAddress> OpenAddresses { get; set; }
        public bool IsDeleted { get; set; }
    }
}
