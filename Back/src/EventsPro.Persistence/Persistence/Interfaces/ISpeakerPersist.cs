using EventsPro.Domain.Entities;

namespace EventsPro.Persistence.Persistence.Interfaces
{
    public interface ISpeakerPersist
    { 
         Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false);
         Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false);
         Task<Speaker> GetSpeakerByIdAsync(int id, bool includeEvents = false);
    }
}