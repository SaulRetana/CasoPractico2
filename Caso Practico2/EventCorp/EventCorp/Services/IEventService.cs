using System.Collections.Generic;
using System.Threading.Tasks;
using EventCorp.Data;
using EventCorp.Models;

namespace EventCorp.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Evento>> GetAllEventsAsync();
        Task<Evento> GetEventByIdAsync(int id);
        Task AddEventAsync(Evento eventModel);
        Task UpdateEventAsync(Evento eventModel);
        Task DeleteEventAsync(int id);
    }
}