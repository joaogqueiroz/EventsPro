using EventsPro.Persistence.Data;
using EventsPro.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventsPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{

    private readonly EventsProContext _dataContext;

    public EventsController(EventsProContext dataContext)
    {
        _dataContext = dataContext;
    }
    [HttpGet()]
    public IEnumerable<Event> Get()
    {
        var events = _dataContext.Events;
        return events;
    }
    [HttpGet("{id}")]
    public Event GetById(int id)
    {
        var eventReturn = _dataContext.Events.FirstOrDefault(x => x.Id == id);
        return eventReturn;
    }
}
