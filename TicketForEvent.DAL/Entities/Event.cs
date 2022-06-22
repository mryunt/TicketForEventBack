using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Entities
{
    public class Event : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventTypeFK { get; set; }
        public int SalonId { get; set; }
        public Salon SalonFK { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string Explanation { get; set; }
        public bool IsDeleted { get; set; }
    }
}
