using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.Country;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly TicketForEventDbContext _ticketForEventDbContext;
        public CountryService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListCountryDto>> GetCountryList()
        {
            return await _ticketForEventDbContext.Countries.Where(p => !p.IsDeleted).Select(p => new GetListCountryDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
        }
        public async Task<GetCountryDto> GetCountryById(int id)
        {
            return await _ticketForEventDbContext.Countries.Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetCountryDto
            {
                Id = p.Id,
                Name = p.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddCountry(AddCountryDto addCountryDto)
        {
            var newCountry = new Country
            {
                Name = addCountryDto.Name
            };
            await _ticketForEventDbContext.Countries.AddAsync(newCountry);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateCountry(int id, UpdateCountryDto updateCountryDto)
        {
            var currentCountry = await _ticketForEventDbContext.Countries.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCountry != null)
            {
                currentCountry.Name = updateCountryDto.Name;
                currentCountry.MDate = DateTime.Now;
                _ticketForEventDbContext.Countries.Update(currentCountry);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteCountry(int id)
        {
            var currentCounrty = await _ticketForEventDbContext.Countries.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCounrty != null)
            {
                currentCounrty.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
            
        }



    }
}
