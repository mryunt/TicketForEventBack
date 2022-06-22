using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketForEvent.DAL.Dtos.Salon
{
    public class GetSalonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OpenAddressId { get; set; }
        public string OpenAddress { get; set; }

    }
}
