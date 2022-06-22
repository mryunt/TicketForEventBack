using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Entities
{
    public class Salon : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OpenAddresId { get; set; }
        public OpenAddress OpenAddressFK { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<SalonSeat> SalonSeats { get; set; }
        public bool IsDeleted { get; set; }
    }
}
