using EventsPro.Persistence.Context;
using EventsPro.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EventsPro.Application.Services.Interfaces;

namespace EventsPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{

    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        try
        {
            var events = await _eventService.GetAllEventsAsync(true);
            if(events == null) return NotFound("Events not found");
        
            return Ok(events);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Error when trying to get Events. Error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var events = await _eventService.GetEventByIdAsync(id, true);
            if(events == null) return NotFound("Event by id not found");
        
            return Ok(events);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Error when trying to get Event. Error: {ex.Message}");
        }
    }
    [HttpGet("theme/{theme}")]
    public async Task<IActionResult> GetByTheme(string theme)
    {
        try
        {
            var events = await _eventService.GetAllEventsByThemeAsync(theme, true);
            if(events == null) return NotFound("Event by theme not found");
        
            return Ok(events);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Error when trying to get Event. Error: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(Event model)
    {
        try
        {
            var eventAdded = await _eventService.AddEvent(model);
            if(eventAdded == null) return BadRequest("Event can't be added");
        
            return Ok(eventAdded);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Error when trying to add Event. Error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Event model)
    {
        try
        {
            var eventUpdated = await _eventService.UpdateEvent(id, model);
            if(eventUpdated == null) return BadRequest("Event can't be updated");
        
            return Ok(eventUpdated);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Error when trying to update Event. Error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (await _eventService.DeleteEvent(id))
            {
                return Ok("Deleted");
            }
            else
            {
                return BadRequest("Event can't be deleted");
            }
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Error when trying to delete Event. Error: {ex.Message}");
        }
    }
}