using Microsoft.AspNetCore.Mvc;

namespace LoginApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;
        public LoginController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (await _userService.AuthenticateAsync(user.Username, user.Password))
            {
                return Ok("Login successfull!" + user.Username + " / " + user.Password);
            }
            return Unauthorized("Username or password incorrect!");
        }
    }
}
