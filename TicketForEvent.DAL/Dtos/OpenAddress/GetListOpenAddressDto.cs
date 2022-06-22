using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.OpenAddress
{
    public class GetListOpenAddressDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }
        public int TownshipId { get; set; }
        public string TownshipName { get; set; }
        public int StreetId { get; set; }
        public string StreetName { get; set; }
    }
}
