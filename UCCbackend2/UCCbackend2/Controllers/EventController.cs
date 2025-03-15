using UCCbackend2.Models;
using UCCbackend2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

//https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-9.0&tabs=windows

namespace UCCbackend2.Controllers
{

    [EnableCors("_myAllowSpecificOrigins")]
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetByUser(string UserId)
        {
            // "67d18275cc31d174b300cc9c" Doesn't work from postman, but works hardcoded.
            var result = await _eventService.GetByUserAsync(UserId);
            return Ok(result);
        }

        // PUT: api/User/id Put doesn't seem to work
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Event e)
        {
            Event oldEvent = await _eventService.GetAsync(id);
            e.id = oldEvent.id;

            if (oldEvent is null)
            {
                return NotFound();
            }
            await _eventService.UpdateAsync(id, e);
            return Ok(e);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event e)
        {
            var result = await _eventService.CreateAsync(e);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _eventService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("post")]
        public IActionResult PostParam([FromBody]Event data)
        {
            
            return Ok(data);
        }
    }
}
