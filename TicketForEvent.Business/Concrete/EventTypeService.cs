using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.Business.Abstract;
using TicketForEvent.DAL.Context;
using TicketForEvent.DAL.Dtos.EventType;
using TicketForEvent.DAL.Entities;

namespace TicketForEvent.Business.Concrete
{
    public class EventTypeService : IEventTypeService
    {
        public readonly TicketForEventDbContext _ticketForEventDbContext;
        public EventTypeService(TicketForEventDbContext ticketForEventDbContext)
        {
            _ticketForEventDbContext = ticketForEventDbContext;
        }

        public async Task<List<GetListEventTypeDto>> GetEventTypeList()
        {
            return await _ticketForEventDbContext.EventTypes.Where(p => !p.IsDeleted).Select(p => new GetListEventTypeDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
        }
        public async Task<GetEventTypeDto> GetEventTypeById(int id)
        {
            return await _ticketForEventDbContext.EventTypes.Where(p => !p.IsDeleted).Select(p => new GetEventTypeDto
            {
                Id = p.Id,
                Name = p.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddEventType(AddEventTypeDto addEventTypeDto)
        {
            var newEventType = new EventType
            {
                Name = addEventTypeDto.Name
            };
            await _ticketForEventDbContext.EventTypes.AddAsync(newEventType);
            return await _ticketForEventDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateEventType(int id, UpdateEventTypeDto updateEventTypeDto)
        {
            var currentEventType = await _ticketForEventDbContext.EventTypes.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if(currentEventType != null)
            {
                currentEventType.Name = updateEventTypeDto.Name;
                currentEventType.MDate = DateTime.Now;
                _ticketForEventDbContext.EventTypes.Update(currentEventType);
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<int> DeleteEventType(int id)
        {
            var currentEventType = await _ticketForEventDbContext.EventTypes.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentEventType != null)
            {
                currentEventType.IsDeleted = true;
                return await _ticketForEventDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
