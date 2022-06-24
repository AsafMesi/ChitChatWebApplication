using Microsoft.AspNetCore.Mvc;

using Domain;
using Services;

namespace ChitChatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IUsersService _usersService;

        public TransferController(ILogger<ContactsController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        // POST: /api/Transfer/
        [HttpPost]
        public IActionResult Transfer([FromBody] ApiTransfer apiTransfer)
        {
            Chat chat = _usersService.GetChat(apiTransfer.to, apiTransfer.from);
            if (chat == null)
            {
                return NotFound();
            }
            MessageWrapper AddedMessage = chat.AddMessage(apiTransfer.content, apiTransfer.from);
            if (AddedMessage == null)
            {
                return BadRequest();
            }
            _usersService.UpdateLastMessage(apiTransfer.from, AddedMessage.Content, AddedMessage.Created, apiTransfer.to);
            if (_usersService.GetUser(apiTransfer.from) != null) // We are in the same server
            {
                _usersService.UpdateLastMessage(apiTransfer.to, AddedMessage.Content, AddedMessage.Created, apiTransfer.from);
            }
            return StatusCode(201);
        }
    }
}


