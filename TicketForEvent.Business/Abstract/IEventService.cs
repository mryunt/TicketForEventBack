using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Event;

namespace TicketForEvent.Business.Abstract
{
    public interface IEventService : IEntity
    {
        public Task<List<GetListEventDto>> GetEvenList();
        public Task<GetEventDto> GetEventById(int id);
        public Task<int> AddEvent(AddEventDto addEventDto);
        public Task<int> UpdateEvent(int id, UpdateEventDto updateEventDto);
        public Task<int> DeleteEvent(int id);
    }
}
