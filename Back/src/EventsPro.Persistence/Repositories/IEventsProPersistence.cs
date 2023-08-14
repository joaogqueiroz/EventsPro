using EventsPro.Domain.Entities;

namespace EventsPro.Persistence.Repositories
{
    public interface IEventsProPersistence
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void DeleteRange<T>(T[] entityArray) where T : class;
         Task<bool> SaveChangesAsync();

         //Events
         Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
         Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
         Task<Event> GetEventByIdAsync(int id, bool includeSpeakers);
         
         //Speakers
         Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents);
         Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
         Task<Speaker> GetSpeakerByIdAsync(int id, bool includeEvents);
    }
}