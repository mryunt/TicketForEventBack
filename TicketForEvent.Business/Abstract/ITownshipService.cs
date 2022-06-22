using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Township;

namespace TicketForEvent.Business.Abstract
{
    public interface ITownshipService : IEntity
    {
        public Task<List<GetListTownshipDto>> GetTownshipList();
        public Task<GetTownshipDto> GetTownshipById(int id);
        public Task<int> AddTownship(AddTownshipDto addTownshipDto);
        public Task<int> UpdateTownship(int id, UpdateTownshipDto updateTownshipDto);
        public Task<int> DeleteTownship(int id);
    }
}
