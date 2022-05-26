using Microsoft.AspNetCore.Mvc;

using Domain;
using Services;

namespace ChitChatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IUsersService _usersService;

        public InvitationsController(ILogger<ContactsController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        // POST: /api/invitations/
        [HttpPost]
        public IActionResult Invitations([FromBody] ApiInvitations apiInvitations)
        {
            if (_usersService.GetUser(apiInvitations.to) == null)
            {
                return NotFound();
            }
            if ((apiInvitations.from == apiInvitations.to) && 
                (apiInvitations.server == _usersService.GetServername()))
            {
                return BadRequest(); // try adding yourself.
            }
            if (_usersService.GetUserContact(apiInvitations.to, apiInvitations.from) != null)
            {
                return BadRequest(); // already exists in the contacts list.
            }
            List<Contact> contacts = _usersService.GetUserContacts(apiInvitations.to);
            if (contacts == null)
            {
                return BadRequest();
            }
            IContactsService _contactsService = new ContactsService() { _contacts = contacts };
            if (!_contactsService.Create(apiInvitations.from, apiInvitations.from, apiInvitations.server))
            {
                return BadRequest();
            }
            _usersService.AddChat(apiInvitations.from, apiInvitations.to);

            if (_usersService.GetUser(apiInvitations.from) != null) // We are in the same server
            {
                // no error checking in this scope.
                List<Contact> fromContacts = _usersService.GetUserContacts(apiInvitations.from);
                _contactsService = new ContactsService() { _contacts = fromContacts };
                _contactsService.Create(apiInvitations.to, apiInvitations.to, apiInvitations.server);
            }

            return StatusCode(201);
        }
    }
}

/**
         {
            List<Contact> contacts = _usersService.GetUserContacts(LoggedUser);
            if (contacts == null)
            {
                return BadRequest();
            }
            IContactsService _contactsService = new ContactsService(contacts);
            if (!_contactsService.Create(newContact.id, newContact.name, newContact.server))
            {
                return BadRequest();
            }
            _usersService.AddChat(newContact.id, LoggedUser);
            return Ok();
        }
 */

