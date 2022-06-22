using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Seat;

namespace TicketForEvent.Business.Abstract
{
    public interface ISeatService : IEntity
    {
        public Task<List<GetListSeatDto>> GetSeatList();
        public Task<GetSeatDto> GetSeatById(int id);
        public Task<int> AddSeat(AddSeatDto addSeatDto);
        public Task<int> UpdateSeat(int id, UpdateSeatDto updateSeatDto);
        public Task<int> DeleteSeat(int id);

    }
}
