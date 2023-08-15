using EventsPro.Persistence.Context;
using EventsPro.Persistence.Persistence.Interfaces;

namespace EventsPro.Persistence.Persistence
{
    public class GeneralPersist : IGeneralPersist
    {
        private readonly EventsProContext _context;
        public GeneralPersist(EventsProContext context)
        {
            _context = context;

        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}