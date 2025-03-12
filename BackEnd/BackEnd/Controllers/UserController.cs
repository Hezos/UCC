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

        [HttpPost("current")]
        public async Task<IActionResult> Get([FromBody]string id)
        {
            var result = await _userService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            var registered = await _userService.CreateAsync(user);
            return Ok(registered);
        }


    }
}
