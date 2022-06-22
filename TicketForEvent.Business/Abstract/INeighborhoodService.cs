using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Neighborhood;

namespace TicketForEvent.Business.Abstract
{
    public interface INeighborhoodService : IEntity
    {
        public Task<List<GetListNeighborhoodDto>> GetNeighborhoodList();
        public Task<GetNeighborhoodDto> GetNeighborhoodById(int id);
        public Task<int> AddNeighborhood(AddNeighborhoodDto addNeighborhoodDto);
        public Task<int> UpdateNeighborhood(int id, UpdateNeighborhoodDto updateNeighborhoodDto);
        public Task<int> DeleteNeighborhood(int id);
    }
}
