using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Entities
{
    public class Country : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<OpenAddress> OpenAddresses { get; set; }
        public bool IsDeleted { get; set; }
    }
}
