using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.OpenAddress
{
    public class AddOpenAddressDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int NeighborhoodId { get; set; }
        public int TownshipId { get; set; }
        public int StreetId { get; set; }
    }
}
