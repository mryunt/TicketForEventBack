using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.SalonSeat
{
    public class GetSalonSeatDto
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public int SeatId { get; set; }
        public string SeatNo { get; set; }
        public int SeatPrice { get; set; }

    }
}
