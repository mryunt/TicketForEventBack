using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.OpenAddress;

namespace TicketForEvent.Business.Abstract
{
    public interface IOpenAddressService : IEntity
    {
        public Task<List<GetListOpenAddressDto>> GetOpenAddressList();
        public Task<GetOpenAddressDto> GetOpenAddressById(int id);
        public Task<int> AddOpenAddress(AddOpenAddressDto openAddressDto);
        public Task<int> UpdateOpenAddress(int id, UpdateOpenAddressDto updateOpenAddressDto);
        public Task<int> DeleteOpenAddress(int id);
    }
}
