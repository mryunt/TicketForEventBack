using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.City;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class CityService : ICityService
    {
        private readonly TicketForEventDbContext _ticketForEventDbContext;
        public CityService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }
        public async Task<List<GetListCityDto>> GetCityList()
        {
            return await _ticketForEventDbContext.Cities.Include(p => p.CountryFK).Where(p => !p.IsDeleted).Select(p => new GetListCityDto
            {
                Id = p.Id,
                Name = p.Name,
                CountryId = p.CountryFK.Id,
                CountryName = p.CountryFK.Name
            }).ToListAsync();
        }
        public async Task<GetCityDto> GetCityById(int id)
        {
            return await _ticketForEventDbContext.Cities.Include(p => p.CountryFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetCityDto
            {
                Id = p.Id,
                Name = p.Name,
                CountryId = p.CountryFK.Id,
                CountryName = p.CountryFK.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<int> AddCity(AddCityDto addCityDto)
        {
            var newCity = new City
            {
                Name = addCityDto.Name,
                CountryID = addCityDto.CountryId
            };
            await _ticketForEventDbContext.Cities.AddAsync(newCity);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateCity(int id, UpdateCityDto updateCityDto)
        {
            var currentCity = await _ticketForEventDbContext.Cities.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if ( currentCity != null)
            {
                currentCity.Name = updateCityDto.Name;
                currentCity.CountryID = updateCityDto.CountryId;
                currentCity.MDate = DateTime.Now;
                _ticketForEventDbContext.Cities.Update(currentCity);
                return await _ticketForEventDbContext.SaveChangesAsync();

            }
            return -1;
        }

        public async Task<int> DeleteCity(int id)
        {
            var currentCity = await _ticketForEventDbContext.Cities.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCity != null)
            {
                currentCity.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
