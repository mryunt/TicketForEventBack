using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.Street
{
    public class AddStreetDto
    {
        public string Name { get; set; }
        public int NeighborhoodId { get; set; }
    }
}
