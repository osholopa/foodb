using FoodbWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using FoodbWebAPI.Dtos;

namespace FoodbWebAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userRepository)
        {
            _userService = userRepository;
        }


        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDto credentials)
        {
            var access_token = _userService.Authenticate(credentials);
            if (access_token == null)
            {
                return Unauthorized();
            }
            return Ok(new { access_token });
        }

    }
}