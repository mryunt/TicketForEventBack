using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.Township;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class TownshipService : ITownshipService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public TownshipService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }
        public async Task<List<GetListTownshipDto>> GetTownshipList()
        {
            return await _ticketForEventDbContext.Townships.Include(p => p.CityFK).Where(p => !p.IsDeleted).Select(p => new GetListTownshipDto
            {
                Id = p.Id,
                Name = p.Name,
                CityId = p.CityFK.Id,
                CityName = p.CityFK.Name
            }).ToListAsync();
        }
        public async Task<GetTownshipDto> GetTownshipById(int id)
        {
            return await _ticketForEventDbContext.Townships.Include(p => p.CityFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetTownshipDto
            {
                Id = p.Id,
                Name = p.Name,
                CityId = p.CityFK.Id,
                CityName = p.CityFK.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddTownship(AddTownshipDto addTownshipDto)
        {
            var newTownship = new Township
            {
                Name = addTownshipDto.Name,
                CityId = addTownshipDto.CityId
            };
            await _ticketForEventDbContext.Townships.AddAsync(newTownship);
            return await _ticketForEventDbContext.SaveChangesAsync();

        }
        public async Task<int> UpdateTownship(int id, UpdateTownshipDto updateTownshipDto)
        {
            var currentTownship = await _ticketForEventDbContext.Townships.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if ( currentTownship != null)
            {
                currentTownship.Name = updateTownshipDto.Name;
                currentTownship.CityId = updateTownshipDto.CityId;
                currentTownship.MDate = DateTime.Now;
                _ticketForEventDbContext.Townships.Update(currentTownship);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteTownship(int id)
        {
            var currentTownship = await _ticketForEventDbContext.Townships.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentTownship != null)
            {
                currentTownship.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
