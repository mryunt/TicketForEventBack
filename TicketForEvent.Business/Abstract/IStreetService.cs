using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Street;

namespace TicketForEvent.Business.Abstract
{
    public interface IStreetService : IEntity
    {
        public Task<List<GetListStreetDto>> GetStreetList();
        public Task<GetStreetDto> GetStreetById(int id);
        public Task<int> AddStreet(AddStreetDto addStreetDto);
        public Task<int> UpdateStreet(int id, UpdateStreetDto updateStreetDto);
        public Task<int> DeleteStreet(int id);
    }
}
