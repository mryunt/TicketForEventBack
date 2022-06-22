using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.Seat;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class SeatService : ISeatService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public SeatService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListSeatDto>> GetSeatList()
        {
            return await _ticketForEventDbContext.Seats.Where(p => !p.IsDeleted).Select(p => new GetListSeatDto
            {
                SeatId = p.Id,
                SeatNo = p.SeatNo,
                SeatPrice = p.SeatPrice
            }).ToListAsync();
        }
        public async Task<GetSeatDto> GetSeatById(int id)
        {
            return await _ticketForEventDbContext.Seats.Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetSeatDto
            {
                SeatId = p.Id,
                SeatNo = p.SeatNo,
                SeatPrice = p.SeatPrice
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddSeat(AddSeatDto addSeatDto)
        {
            var newSeat = new Seat
            {
                SeatNo = addSeatDto.SeatNo,
                SeatPrice = addSeatDto.SeatPrice
            };
            await _ticketForEventDbContext.Seats.AddAsync(newSeat);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateSeat(int id, UpdateSeatDto updateSeatDto)
        {
            var currentSeat = await _ticketForEventDbContext.Seats.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if(currentSeat != null)
            {
                currentSeat.SeatNo = updateSeatDto.SeatNo;
                currentSeat.SeatPrice = updateSeatDto.SeatPrice;
                currentSeat.MDate = DateTime.Now;
                _ticketForEventDbContext.Seats.Update(currentSeat);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<int> DeleteSeat(int id)
        {
            var currentSeat = await _ticketForEventDbContext.Seats.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentSeat != null)
            {
                currentSeat.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
