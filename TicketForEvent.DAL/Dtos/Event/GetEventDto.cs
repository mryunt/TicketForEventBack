using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.Event
{
    public class GetEventDto
    {
        public int Id { get; set; }
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
