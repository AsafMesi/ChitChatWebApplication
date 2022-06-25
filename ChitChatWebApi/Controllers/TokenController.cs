using Microsoft.AspNetCore.Mvc;

using Domain;
using Services;
using Microsoft.AspNetCore.SignalR;
using ChitChatWebApi.Hubs;


namespace ChitChatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IUsersService _usersService;

        public TokenController(ILogger<ContactsController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }


        // POST: /api/Token/
        [HttpPost("{LoggedUser}")]
        public async IActionResult getToken([FromBody] string token, string LoggedUser)
        {
            string localToken = UsersService.getTokenByUsername(LoggedUser);
            if (localToken == token)
            {
                return Ok();
            }
            else if (localToken == null)
            {
                UsersService.addToken(LoggedUser, token);
                return Ok();
            }
            return NotFound();
        }
    }
}


