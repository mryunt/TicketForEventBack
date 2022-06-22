using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.Salon;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class SalonService : ISalonService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public SalonService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListSalonDto>> GetSalonList()
        {
            return await _ticketForEventDbContext.Salons.Include(p => p.OpenAddressFK).Where(p => !p.IsDeleted).Select(p => new GetListSalonDto
            {
                Id = p.Id,
                Name = p.Name,
                OpenAddressId = p.OpenAddressFK.Id,
                OpenAddress = p.OpenAddressFK.Name
            }).ToListAsync();
        }
        public async Task<GetSalonDto> GetSalonById(int id)
        {
            return await _ticketForEventDbContext.Salons.Include(p => p.OpenAddressFK).Where(p => !p.IsDeleted).Select(p => new GetSalonDto
            {
                Id = p.Id,
                Name = p.Name,
                OpenAddressId = p.OpenAddressFK.Id,
                OpenAddress = p.OpenAddressFK.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddSalon(AddSalonDto addSalonDto)
        {
            var newSalon = new Salon
            {
                Name = addSalonDto.Name,
                OpenAddresId = addSalonDto.OpenAddressId
            };
            await _ticketForEventDbContext.Salons.AddAsync(newSalon);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateSalon(int id, UpdateSalonDto updateSalonDto)
        {
            var currentSalon = await _ticketForEventDbContext.Salons.Where(p => !p.IsDeleted).FirstOrDefaultAsync();
            if(currentSalon != null)
            {
                currentSalon.Name = updateSalonDto.Name;
                currentSalon.OpenAddresId = updateSalonDto.OpenAddressId;
                currentSalon.MDate = DateTime.Now;
                _ticketForEventDbContext.Salons.Update(currentSalon);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteSalon(int id)
        {
            var currentSalon = await _ticketForEventDbContext.Salons.Where(p => !p.IsDeleted).FirstOrDefaultAsync();
            if (currentSalon != null)
            {
                currentSalon.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
