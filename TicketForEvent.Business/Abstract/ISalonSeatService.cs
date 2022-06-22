using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.SalonSeat;

namespace TicketForEvent.Business.Abstract
{
    public interface ISalonSeatService : IEntity
    {
        public Task<List<GetListSalonSeatDto>> GetSalonSeatList();
        public Task<GetSalonSeatDto> GetSalonSeatById(int id);
        public Task<int> AddSalonSeat(AddSalonSeatDto addSalonSeatDto);
        public Task<int> UpdateSalonSeat(int id, UpdateSalonSeatDto updateSalonSeatDto);
        public Task<int> DeleteSalonSeat(int id);
    }
}
