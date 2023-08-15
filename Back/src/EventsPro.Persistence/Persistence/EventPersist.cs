using EventsPro.Domain.Entities;
using EventsPro.Persistence.Context;
using EventsPro.Persistence.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventsPro.Persistence.Persistence
{
    public class EventPersist : IEventPersist
    {
        private readonly EventsProContext _context;
        public EventPersist(EventsProContext context)
        {
            _context = context;

        }
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }
            query = query.OrderBy(e => e.Id);
            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }
            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }
            query = query.AsNoTracking().Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}