using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.SalonSeat
{
    public class UpdateSalonSeatDto
    {
        public int SalonId { get; set; }
        public string SeatId { get; set; }
    }
}
