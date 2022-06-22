using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Entities
{
    public class SalonSeat : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public Salon SalonFK { get; set; }
        public int SeatId { get; set; }
        public Seat SeatFK { get; set; }
        public bool IsDeleted { get; set; }
    }
}
