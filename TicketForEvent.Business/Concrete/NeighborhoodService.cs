using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.Neighborhood;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class NeighborhoodService : INeighborhoodService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public NeighborhoodService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListNeighborhoodDto>> GetNeighborhoodList()
        {
            return await _ticketForEventDbContext.Neighborhoods.Include(p => p.TownshipFK).Where(p => !p.IsDeleted).Select(p => new GetListNeighborhoodDto
            {
                Id = p.Id,
                Name = p.Name,
                TownshipId = p.TownshipFK.Id,
                TownshipName = p.TownshipFK.Name
            }).ToListAsync();
        }
        public async Task<GetNeighborhoodDto> GetNeighborhoodById(int id)
        {
            return await _ticketForEventDbContext.Neighborhoods.Include(p => p.TownshipFK).Where(p => !p.IsDeleted).Select(p => new GetNeighborhoodDto
            {
                Id = p.Id,
                Name = p.Name,
                TownshipId = p.TownshipFK.Id,
                TownshipName = p.TownshipFK.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddNeighborhood(AddNeighborhoodDto addNeighborhoodDto)
        {
            var newNeighborhood = new Neighborhood
            {
                Name = addNeighborhoodDto.Name,
                TownshipId = addNeighborhoodDto.TownshipId
            };
            await _ticketForEventDbContext.Neighborhoods.AddAsync(newNeighborhood);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateNeighborhood(int id, UpdateNeighborhoodDto updateNeighborhoodDto)
        {
            var currentNeighborhood = await _ticketForEventDbContext.Neighborhoods.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentNeighborhood != null)
            {
                currentNeighborhood.Name = updateNeighborhoodDto.Name;
                currentNeighborhood.TownshipId = updateNeighborhoodDto.TownshipId;
                currentNeighborhood.MDate = DateTime.Now;
                _ticketForEventDbContext.Neighborhoods.Update(currentNeighborhood);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteNeighborhood(int id)
        {
            var currentNeighborhood = await _ticketForEventDbContext.Neighborhoods.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentNeighborhood != null)
            {
                currentNeighborhood.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
