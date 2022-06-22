using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.Seat
{
    public class GetSeatDto
    {
        public int SeatId { get; set; }
        public string SeatNo { get; set; }
        public int SeatPrice { get; set; }

    }
}
