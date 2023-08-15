using EventsPro.Domain.Entities;
using EventsPro.Persistence.Context;
using EventsPro.Persistence.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventsPro.Persistence.Persistence
{
    public class SpeakerPersist : ISpeakerPersist
    {
        private readonly EventsProContext _context;
        public SpeakerPersist(EventsProContext context)
        {
            _context = context;

        }
        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query.Include(s => s.SpeakersEvents)
                .ThenInclude(se => se.Event);
            }
            query = query.OrderBy(s => s.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query.Include(s => s.SpeakersEvents)
                .ThenInclude(se => se.Event);
            }
            query = query.OrderBy(s => s.Id)
                        .Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }


        public async Task<Speaker> GetSpeakerByIdAsync(int id, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query.Include(s => s.SpeakersEvents)
                .ThenInclude(se => se.Event);
            }
            query = query.Where(s => s.Id == id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

    }
}