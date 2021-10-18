using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psyent.Models;
using Psyent.Services.CustomExceptions;
using Psyent.Services.Services.Interfaces;

namespace Psyent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        //[AllowAnonymous]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            try
            {
                UserModel user = _userService.Authenticate(model.Username, model.Password);
                if (user == null)
                {
                    return NotFound("User does not exist");
                }
                return Ok(user);
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        //[Authorize]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            try
            {
                _userService.Register(model);
                return Ok("Successfully registered user!");
            }
            catch
            {
                return BadRequest("Something went wrong! Please try again later");
            }
        }
    }
}
