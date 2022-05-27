using Microsoft.AspNetCore.Mvc;

using Domain;
using Services;

namespace ChitChatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IUsersService _usersService;
        public RegisterController(ILogger<ContactsController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        // POST: /api/Register/
        [HttpPost()]
        public IActionResult Register([FromBody] ApiUserRegister apiUser)
        {
            if (!_usersService.CreateUser(apiUser.id, apiUser.name, apiUser.password))
            {
                return BadRequest();
            }
            ApiContact res = _usersService.GetUser(apiUser.id);
            return Ok(res);
        }
    }
}