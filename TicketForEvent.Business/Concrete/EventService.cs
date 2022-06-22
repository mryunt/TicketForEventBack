using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.Event;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class EventService : IEventService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public EventService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListEventDto>> GetEvenList()
        {
            return await _ticketForEventDbContext.Events.Include(p => p.EventTypeFK).Include(p => p.SalonFK).Where(p => !p.IsDeleted).Select(p => new GetListEventDto
            {
                Id = p.Id,
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Explanation = p.Explanation,
                EventTypeId = p.EventTypeFK.Id,
                EventTypeName = p.EventTypeFK.Name,
                SalonId = p.SalonFK.Id,
                SalonName = p.SalonFK.Name
            }).ToListAsync();
        }
        public async Task<GetEventDto> GetEventById(int id)
        {
            return await _ticketForEventDbContext.Events.Include(p => p.EventTypeFK).Include(p => p.SalonFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetEventDto
            {
                Id = p.Id,
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Explanation = p.Explanation,
                EventTypeId = p.EventTypeFK.Id,
                EventTypeName = p.EventTypeFK.Name,
                SalonId = p.SalonFK.Id,
                SalonName = p.SalonFK.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddEvent(AddEventDto addEventDto)
        {
            var newEvent = new Event
            {
                Name = addEventDto.Name,
                EventTypeId = addEventDto.EventTypeId,
                SalonId = addEventDto.SalonId,
                StartDate = addEventDto.StartDate,
                EndDate = addEventDto.EndDate,
                Explanation = addEventDto.Explanation,
                Image = addEventDto.Image
            };
            await _ticketForEventDbContext.Events.AddAsync(newEvent);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEvent(int id, UpdateEventDto updateEventDto)
        {
            var currentEvent = await _ticketForEventDbContext.Events.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if(currentEvent != null)
            {
                currentEvent.Name = updateEventDto.Name;
                currentEvent.EventTypeId = updateEventDto.EventTypeId;
                currentEvent.SalonId = updateEventDto.SalonId;
                currentEvent.StartDate = updateEventDto.StartDate;
                currentEvent.EndDate = updateEventDto.EndDate;
                currentEvent.Explanation = updateEventDto.Explanation;
                currentEvent.Image = updateEventDto.Image;
                currentEvent.MDate = DateTime.Now;
                _ticketForEventDbContext.Events.Update(currentEvent);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteEvent(int id)
        {
            var currentEvent = await _ticketForEventDbContext.Events.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentEvent != null)
            {
                currentEvent.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
