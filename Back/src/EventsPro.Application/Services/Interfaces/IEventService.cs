using EventsPro.Domain.Entities;

namespace EventsPro.Application.Services.Interfaces
{
    public interface IEventService
    {
         Task<Event> AddEvent(Event model);
         Task<Event> UpdateEvent(int id, Event model);
         Task<bool> DeleteEvent(int id);
         Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
         Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
         Task<Event> GetEventByIdAsync(int id, bool includeSpeakers = false);

    }
}