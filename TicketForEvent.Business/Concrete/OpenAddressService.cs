using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.OpenAddress;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class OpenAddressService : IOpenAddressService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public OpenAddressService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListOpenAddressDto>> GetOpenAddressList()
        {
            return await _ticketForEventDbContext.OpenAddresses.Include(p => p.CountryFK).Include(p => p.CityFK)
                .Include(p => p.TownshipFK).Include(p => p.NeighborhoodFK).Include(p => p.StreetFK).Where(p => !p.IsDeleted).Select(p => new GetListOpenAddressDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CountryId = p.CountryFK.Id,
                    CountryName = p.CountryFK.Name,
                    CityId = p.CityFK.Id,
                    CityName = p.CityFK.Name,
                    TownshipId = p.TownshipFK.Id,
                    TownshipName = p.TownshipFK.Name,
                    NeighborhoodId = p.NeighborhoodFK.Id,
                    NeighborhoodName = p.NeighborhoodFK.Name,
                    StreetId = p.StreetFK.Id,
                    StreetName = p.StreetFK.Name
                }).ToListAsync();
        }
        public async Task<GetOpenAddressDto> GetOpenAddressById(int id)
        {
            return await _ticketForEventDbContext.OpenAddresses.Include(p => p.CountryFK).Include(p => p.CityFK)
                .Include(p => p.TownshipFK).Include(p => p.NeighborhoodFK).Include(p => p.StreetFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetOpenAddressDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CountryId = p.CountryFK.Id,
                    CountryName = p.CountryFK.Name,
                    CityId = p.CityFK.Id,
                    CityName = p.CityFK.Name,
                    TownshipId = p.TownshipFK.Id,
                    TownshipName = p.TownshipFK.Name,
                    NeighborhoodId = p.NeighborhoodFK.Id,
                    NeighborhoodName = p.NeighborhoodFK.Name,
                    StreetId = p.StreetFK.Id,
                    StreetName = p.StreetFK.Name
                }).FirstOrDefaultAsync();
        }
        public async Task<int> AddOpenAddress(AddOpenAddressDto openAddressDto)
        {
            var newOpenAddress = new OpenAddress
            {
                Name = openAddressDto.Name,
                CountryId = openAddressDto.CountryId,
                CityId = openAddressDto.CityId,
                TownshipId = openAddressDto.TownshipId,
                NeighborhoodId = openAddressDto.NeighborhoodId,
                StreetId = openAddressDto.StreetId
            };
            await _ticketForEventDbContext.OpenAddresses.AddAsync(newOpenAddress);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateOpenAddress(int id, UpdateOpenAddressDto updateOpenAddressDto)
        {
            var currentOpenAddress = await _ticketForEventDbContext.OpenAddresses.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentOpenAddress != null)
            {
                currentOpenAddress.Name = updateOpenAddressDto.Name;
                currentOpenAddress.CountryId = updateOpenAddressDto.CountryId;
                currentOpenAddress.CityId = updateOpenAddressDto.CityId;
                currentOpenAddress.TownshipId = updateOpenAddressDto.TownshipId;
                currentOpenAddress.NeighborhoodId = updateOpenAddressDto.NeighborhoodId;
                currentOpenAddress.StreetId = updateOpenAddressDto.StreetId;
                currentOpenAddress.MDate = DateTime.Now;
                _ticketForEventDbContext.OpenAddresses.Update(currentOpenAddress);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteOpenAddress(int id)
        {
            var currentOpenAddress = await _ticketForEventDbContext.OpenAddresses.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentOpenAddress != null)
            {
                currentOpenAddress.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
