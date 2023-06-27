using EventsPro.API.Data;
using EventsPro.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{

    private readonly DataContext _dataContext;

    public EventsController(DataContext dataContext)
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
