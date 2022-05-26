using Microsoft.AspNetCore.Mvc;

using Domain;
using Services;

namespace ChitChatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IUsersService _usersService;
        public LoginController(ILogger<ContactsController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        // POST: /api/Login/
        [HttpPost()]
        public IActionResult Login([FromBody] ApiUserLogin apiUser)
        {
            User user = _usersService.GetUsers().Find(x => (x.Id == apiUser.id) && (x.Password == apiUser.password));

            if (user == null)
            {
                return NotFound();

            }
            ApiContact res = new ApiContact(user.Id, user.Name, user.Server);
            return Ok(res);
        }
    }
}