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
        private readonly IContactsService _contactsService;

        public TransferController(ILogger<ContactsController> logger, IContactsService contactsService)
        {
            _logger = logger;
            _contactsService = contactsService;
        }

        // POST: /api/Transfer/
        [HttpPost]
        public IActionResult Transfer([FromBody] ApiTransfer apiTransfer)
        {
            Chat chat = _contactsService.GetChat(apiTransfer.from, apiTransfer.to);
            if (chat == null)
            {
                return NotFound();
            }
            MessageWrapper AddedMessage = chat.AddMessage(apiTransfer.content, apiTransfer.from);
            if (AddedMessage == null)
            {
                return BadRequest("transfer failed");
            }
            _contactsService.UpdateLastMessage(apiTransfer.to, AddedMessage.Content, AddedMessage.Created, apiTransfer.from);
            return StatusCode(201);
        }
    }
}


