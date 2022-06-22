using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.SalonSeat;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class SalonSeatService : ISalonSeatService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public SalonSeatService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListSalonSeatDto>> GetSalonSeatList()
        {
            return await _ticketForEventDbContext.SalonSeats.Include(p => p.SalonFK).Include(p => p.SeatFK).Where(p => !p.IsDeleted).Select(p => new GetListSalonSeatDto
            {
                Id = p.Id,
                SalonId = p.SalonFK.Id,
                SeatId = p.SeatFK.Id,
                SalonName = p.SalonFK.Name,
                SeatNo = p.SeatFK.SeatNo,
                SeatPrice = p.SeatFK.SeatPrice
            }).ToListAsync();
        }
        public async Task<GetSalonSeatDto> GetSalonSeatById(int id)
        {
            return await _ticketForEventDbContext.SalonSeats.Include(p => p.SalonFK).Include(p => p.SeatFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetSalonSeatDto
            {
                Id = p.Id,
                SalonId = p.SalonFK.Id,
                SeatId = p.SeatFK.Id,
                SalonName = p.SalonFK.Name,
                SeatNo = p.SeatFK.SeatNo,
                SeatPrice = p.SeatFK.SeatPrice
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddSalonSeat(AddSalonSeatDto addSalonSeatDto)
        {
            var newSalonSeat = new SalonSeat
            {
                SalonId = addSalonSeatDto.SalonId,
                SeatId = addSalonSeatDto.SeatId
            };
            await _ticketForEventDbContext.SalonSeats.AddAsync(newSalonSeat);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateSalonSeat(int id, UpdateSalonSeatDto updateSalonSeatDto)
        {
            var currentSalonSeat = await _ticketForEventDbContext.SalonSeats.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if(currentSalonSeat != null)
            {
                currentSalonSeat.SalonId = updateSalonSeatDto.SalonId;
                currentSalonSeat.SeatId = updateSalonSeatDto.SalonId;
                currentSalonSeat.MDate = DateTime.Now;
                _ticketForEventDbContext.SalonSeats.Update(currentSalonSeat);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<int> DeleteSalonSeat(int id)
        {
            var currentSalonSeat = await _ticketForEventDbContext.SalonSeats.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentSalonSeat != null)
            {
                currentSalonSeat.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
