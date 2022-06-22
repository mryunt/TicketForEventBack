using AppCore.Entity;
using System.Collections.Generic;

namespace TicketForEvent.DAL.Entities
{
    public class Street : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int NeighborhoodId { get; set; }
        public Neighborhood NeighborhoodFK { get; set; }
        public ICollection<OpenAddress> OpenAddresses { get; set; }
        public bool IsDeleted { get; set; }
    }
}
