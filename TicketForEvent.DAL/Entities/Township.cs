using AppCore.Entity;
using System.Collections.Generic;

namespace TicketForEvent.DAL.Entities
{
    public class Township : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City CityFK { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
        public ICollection<OpenAddress> OpenAddresses { get; set; }
        public bool IsDeleted { get; set; }
    }
}
