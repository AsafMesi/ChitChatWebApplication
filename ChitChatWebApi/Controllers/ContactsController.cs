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
        private IContactsService _contactsService = new ContactsService();

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        // GET api/contacts   --- > return all LoggedUser contacts.
        [HttpGet("{LoggedUser}")]
        public IActionResult GetContacts(string LoggedUser)
        {
            List<Contact> contacts = _contactsService.GetAll(LoggedUser);
            if (contacts == null) 
            {
                return BadRequest();
            }
            return Ok(contacts);
        }

        // POST api/contacts   --- > add new contact to LoggedUser contacts.
        [HttpPost("{LoggedUser}")]
        public IActionResult AddContact(string id, string name, string server, string LoggedUser)
        {
            if (!_contactsService.Add(id, name, server, LoggedUser))
            {
                return BadRequest();
            }
            return Ok();
        }

        // GET api/contacts/:id
        [HttpGet("{id}/{LoggedUser}")]
        public IActionResult GetContactById(string id, string LoggedUser)
        {
            Contact contact = _contactsService.Get(id, LoggedUser);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // PUT api/contacts/:id
        [HttpPut("{id}/{LoggedUser}")]
        public IActionResult UpdateContactById(string id, string name, string server, string LoggedUser)
        {
            if (!_contactsService.Update(id, name, server, LoggedUser))
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/contacts/:id
        [HttpDelete("{id}/{LoggedUser}")]
        public IActionResult DeleteContactById(string id, string LoggedUser)
        {
            if (!_contactsService.Delete(id, LoggedUser))
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET api/contacts/:id/Messages
        [HttpGet("{id}/Messages/{LoggedUser}")]
        public IActionResult GetMessages(string id, string LoggedUser)
        {
            List<Message> messages = _contactsService.GetMessages(id, LoggedUser);
                if (messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }

        // POST api/contacts/:id/Messages
        [HttpPost("{id}/Messages/{LoggedUser}")]
        public IActionResult AddMessage(string id, string content, string LoggedUser)
        {
            if (!_contactsService.AddMessage(id, content, LoggedUser))
            {
                return BadRequest();
            }
            return NoContent();
        }

        // GET api/contacts/:id/Messages/:id2
        [HttpGet("{id}/Messages/{id2}/{LoggedUser}")]
        public IActionResult getMessageById(string id, int id2, string LoggedUser)
        {
            Message message = _contactsService.GetMessage(id, id2, LoggedUser);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        // Put api/contacts/:id/Messages/:id2
        [HttpPut("{id}/Messages/{id2}/{LoggedUser}")]
        public IActionResult UpdateMessageById(string id, int id2, string content, string LoggedUser)
        {
            if (!_contactsService.UpdateMessage(id, id2, content, LoggedUser))
            {
                return BadRequest();
            }
            return NoContent();
        }

        // Delete api/contacts/:id/Messages/:id2
        [HttpDelete("{id}/Messages/{id2}/{LoggedUser}")]
        public IActionResult DeleteMessageById(string id, int id2, string LoggedUser)
        {
            if (!_contactsService.DeleteMessage(id, id2, LoggedUser))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}