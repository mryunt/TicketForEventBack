using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.Street;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class StreetService : IStreetService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public StreetService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }
        public async Task<List<GetListStreetDto>> GetStreetList()
        {
            return await _ticketForEventDbContext.Streets.Include(p => p.NeighborhoodFK).Where(p => !p.IsDeleted).Select(p => new GetListStreetDto
            {
                Id = p.Id,
                Name = p.Name,
                NeighborhoodId = p.NeighborhoodFK.Id,
                NeighborhoodName = p.NeighborhoodFK.Name
            }).ToListAsync();
        }
        public async Task<GetStreetDto> GetStreetById(int id)
        {
            return await _ticketForEventDbContext.Streets.Include(p => p.NeighborhoodFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetStreetDto
            {
                Id = p.Id,
                Name = p.Name,
                NeighborhoodId = p.NeighborhoodFK.Id,
                NeighborhoodName = p.NeighborhoodFK.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<int> AddStreet(AddStreetDto addStreetDto)
        {
            var newStreet = new Street
            {
                Name = addStreetDto.Name,
                NeighborhoodId = addStreetDto.NeighborhoodId
            };
            await _ticketForEventDbContext.Streets.AddAsync(newStreet);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }




        public async Task<int> UpdateStreet(int id, UpdateStreetDto updateStreetDto)
        {
            var currentStreet = await _ticketForEventDbContext.Streets.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentStreet == null)
            {
                currentStreet.Name = updateStreetDto.Name;
                currentStreet.NeighborhoodId = updateStreetDto.NeighborhoodId;
                currentStreet.MDate = DateTime.Now;
                _ticketForEventDbContext.Streets.Update(currentStreet);
                return await _ticketForEventDbContext.SaveChangesAsync();

            }
            return -1;
        }
        public async Task<int> DeleteStreet(int id)
        {
            var currentStreet = await _ticketForEventDbContext.Streets.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentStreet != null)
            {
                currentStreet.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
