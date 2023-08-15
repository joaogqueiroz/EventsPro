using EventsPro.Application.Services.Interfaces;
using EventsPro.Domain.Entities;
using EventsPro.Persistence.Persistence;
using EventsPro.Persistence.Persistence.Interfaces;

namespace EventsPro.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IEventPersist _eventPersist;

        public EventService(IGeneralPersist generalPersist, IEventPersist eventPersist)
        {
            _generalPersist = generalPersist;
            this._eventPersist = eventPersist;
        }
        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                _generalPersist.Add<Event>(model);
                if (await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int id, Event model)
        {
            try
            {
                var evento = await _eventPersist.GetEventByIdAsync(id);
                if (evento == null) return null;

                model.Id = evento.Id;

                _generalPersist.Update(model);
                if (await _generalPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvent(int id)
        {
            try
            {
                var evento = await _eventPersist.GetEventByIdAsync(id);
                if (evento == null) throw new Exception("Event to delete not found");
                
                _generalPersist.Delete<Event>(evento);
                return await _generalPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var events = _eventPersist.GetAllEventsAsync(includeSpeakers);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                var events = _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeakers);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Event> GetEventByIdAsync(int id, bool includeSpeakers = false)
        {
            try
            {
                var eventById = _eventPersist.GetEventByIdAsync(id, includeSpeakers);
                if (eventById == null) return null;

                return eventById;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}