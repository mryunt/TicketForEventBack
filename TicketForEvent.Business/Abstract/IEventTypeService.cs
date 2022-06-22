using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.EventType;

namespace TicketForEvent.Business.Abstract
{
    public interface IEventTypeService : IEntity
    {
        public Task<List<GetListEventTypeDto>> GetEventTypeList();
        public Task<GetEventTypeDto> GetEventTypeById(int id);
        public Task<int> AddEventType(AddEventTypeDto addEventTypeDto);
        public Task<int> UpdateEventType(int id, UpdateEventTypeDto updateEventTypeDto);
        public Task<int> DeleteEventType(int id);
    }
}
