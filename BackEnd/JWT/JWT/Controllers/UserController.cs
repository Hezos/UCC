using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userService.test();
            return Ok(user);
        }

        //Current should be registered in the FrontEnd
        [HttpPost("current")]
        public async Task<IActionResult> Get([FromBody]string id)
        {
            var result = await _userService.GetAsync(id);
            return Ok(result);
        }

        //Give all the users as coded information
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<User> result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            var registered = await _userService.CreateAsync(user);
            return Ok(registered);
        }

        // PUT: api/User/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] User user)
        {
            User oldUser = await _userService.GetAsync(id);
            user.Id = oldUser.Id;

            if (oldUser is null)
            {
                return NotFound();
            }
            await _userService.UpdateAsync(id, user);
            return Ok(user);
        }

    }
}
