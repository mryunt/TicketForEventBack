using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Country;

namespace TicketForEvent.Business.Abstract
{
    public interface ICountryService : IEntity
    {
        public Task<List<GetListCountryDto>> GetCountryList();
        public Task<GetCountryDto> GetCountryById(int id);
        public Task<int> AddCountry(AddCountryDto addCountryDto);
        public Task<int> UpdateCountry(int id, UpdateCountryDto updateCountryDto);
        public Task<int> DeleteCountry(int id);
    }
}
