using Microsoft.AspNetCore.Mvc;

using Domain;
using Services;

namespace ChitChatWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IUsersService _usersService;
        public ContactsController(ILogger<ContactsController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        // Contacts fucntions:

        // GET api/contacts   ---> return all LoggedUser contacts.
        [HttpGet("{LoggedUser}")]
        public IActionResult GetContacts(string LoggedUser)
        {
            List<Contact> contacts = _usersService.GetUserContacts(LoggedUser);
            if (contacts == null) 
            {
                return BadRequest();
            }
            return Ok(contacts);
        }

        // GET api/contacts/:id
        [HttpGet("{id}/{LoggedUser}")]
        public IActionResult GetContactById(string id, string LoggedUser)
        {
            List<Contact> contacts = _usersService.GetUserContacts(LoggedUser);
            if (contacts == null)
            {
                return NotFound();
            }
            IContactsService _contactsService = new ContactsService() { _contacts = contacts };
            Contact contact = _contactsService.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST api/contacts   --- > add new contact to LoggedUser contacts.
        [HttpPost("{LoggedUser}")]
        public IActionResult AddContact([FromBody] ApiContact newContact, string LoggedUser)
        {
            List<Contact> contacts = _usersService.GetUserContacts(LoggedUser);
            if (contacts == null)
            {
                return BadRequest();
            }
            IContactsService _contactsService = new ContactsService() { _contacts = contacts };
            if (!_contactsService.Create(newContact.id, newContact.name, newContact.server))
            {
                return BadRequest();
            }
            _usersService.AddChat(newContact.id, LoggedUser);
            return Ok();
        }

        // PUT api/contacts/:id
        [HttpPut("{id}/{LoggedUser}")]
        public IActionResult UpdateContactById([FromBody] ApiContact updatedContact, string LoggedUser)
        {
            List<Contact> contacts = _usersService.GetUserContacts(LoggedUser);
            if (contacts == null)
            {
                return BadRequest();
            }
            IContactsService _contactsService = new ContactsService() { _contacts = contacts };
            if (!_contactsService.Update(updatedContact.id, updatedContact.name, updatedContact.server))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/contacts/:id
        [HttpDelete("{id}/{LoggedUser}")]
        public IActionResult DeleteContactById(string id, string LoggedUser)
        {
            List<Contact> contacts = _usersService.GetUserContacts(LoggedUser);
            if (contacts == null)
            {
                return BadRequest();
            }
            IContactsService _contactsService = new ContactsService() { _contacts = contacts };
            if (!_contactsService.Delete(id))
            {
                return NotFound();
            }
            _usersService.DeleteChat(id, LoggedUser);

            List<Contact> contactContacts = _usersService.GetUserContacts(id);
            if (contactContacts != null)
            {
                // no error checking in this scope
                _contactsService = new ContactsService() { _contacts = contacts };
                _contactsService.Delete(LoggedUser);
            }
            return NoContent();
        }


        // Messages functions:

        // GET api/contacts/:id/Messages
        [HttpGet("{id}/Messages/{LoggedUser}")]
        public IActionResult GetMessages(string id, string LoggedUser)
        {
            List<Message> messages = _usersService.GetMessages(id, LoggedUser);
                if (messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }

        // POST api/contacts/:id/Messages
        [HttpPost("{id}/Messages/{LoggedUser}")]
        public IActionResult AddMessage(string id, string LoggedUser, [FromBody] string content)
        {
            if (!_usersService.AddMessage(id, content, LoggedUser))
            {
                return BadRequest();
            }
            return NoContent();
        }

        // GET api/contacts/:id/Messages/:id2
        [HttpGet("{id}/Messages/{id2}/{LoggedUser}")]
        public IActionResult GetMessageById(string id, int id2, string LoggedUser)
        {
            Message message = _usersService.GetMessage(id, id2, LoggedUser);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        // Put api/contacts/:id/Messages/:id2
        [HttpPut("{id}/Messages/{id2}/{LoggedUser}")]
        public IActionResult UpdateMessageById(string id, int id2, [FromBody] string content, string LoggedUser)
        {
            if (!_usersService.UpdateMessage(id, id2, content, LoggedUser))
            {
                return BadRequest();
            }
            return NoContent();
        }

        // Delete api/contacts/:id/Messages/:id2
        [HttpDelete("{id}/Messages/{id2}/{LoggedUser}")]
        public IActionResult DeleteMessageById(string id, int id2, string LoggedUser)
        {
            if (!_usersService.DeleteMessage(id, id2, LoggedUser))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}