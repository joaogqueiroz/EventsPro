using EventsPro.Domain.Entities;

namespace EventsPro.Persistence.Persistence.Interfaces
{
    public interface IEventPersist
    {
         Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
         Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
         Task<Event> GetEventByIdAsync(int id, bool includeSpeakers = false);
    }
}