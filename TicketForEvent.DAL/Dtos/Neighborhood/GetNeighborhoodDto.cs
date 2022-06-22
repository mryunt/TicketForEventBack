using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.Neighborhood
{
    public class GetNeighborhoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TownshipId { get; set; }
        public string TownshipName { get; set; }
    }
}
