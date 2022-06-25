using Microsoft.AspNetCore.Mvc;

using Domain;
using Services;
using Microsoft.AspNetCore.SignalR;
using ChitChatWebApi.Hubs;


namespace ChitChatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IUsersService _usersService;
        private IHubContext<ChatHub> _chatHub;

        public TransferController(ILogger<ContactsController> logger, IUsersService usersService, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _usersService = usersService;
            _chatHub = hubContext;
        }

        // POST: /api/Transfer/
        [HttpPost]
        public async Task<IActionResult> Transfer([FromBody] ApiTransfer apiTransfer)
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
                await _chatHub.Clients.All.SendAsync("TriggerGetContacts");
            }
            return StatusCode(201);
        }
    }
}


