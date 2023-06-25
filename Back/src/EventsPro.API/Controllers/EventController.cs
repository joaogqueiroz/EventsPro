using EventsPro.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsPro.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{


    [HttpGet()]
    public IEnumerable<Event> Get()
    {
        return new IEnumerable<Event>();
    }
}
