using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.City;

namespace TicketForEvent.Business.Abstract
{
    public interface ICityService : IEntity
    {
        public Task<List<GetListCityDto>> GetCityList();
        public Task<GetCityDto> GetCityById(int id);
        public Task<int> AddCity(AddCityDto addCityDto);
        public Task<int> UpdateCity(int id, UpdateCityDto updateCityDto);
        public Task<int> DeleteCity(int id);
    }
}
