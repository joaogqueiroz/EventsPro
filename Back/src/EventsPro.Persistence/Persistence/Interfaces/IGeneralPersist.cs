using EventsPro.Domain.Entities;

namespace EventsPro.Persistence.Persistence.Interfaces
{
    public interface IGeneralPersist
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void DeleteRange<T>(T[] entityArray) where T : class;
         Task<bool> SaveChangesAsync();
    }
}