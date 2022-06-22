using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Entities
{
    public class Seat : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string SeatNo { get; set; }
        public int SeatPrice { get; set; }
        public ICollection<SalonSeat> SalonSeats { get; set; }
        public bool IsDeleted { get; set; }
    }
}
