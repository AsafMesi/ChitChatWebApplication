using Domain;

namespace Services
{
    public class ContactsService : IContactsService
    {
        public List<Contact> _contacts { get; set; }
        public Contact Get(string id)
        {
            Contact contact = _contacts.Find(x => x.Id == id);
            return contact;
        }
        public bool Create(string id, string name, string server)
        {
            Contact contact = Get(id);
            if (contact == null) // if not already exists in contact list.
            {
                Contact NewContact = new Contact(id, name, server, null, null);
                _contacts.Add(NewContact);
                return true;
            }
            return false;
        }
        public bool Update(string id, string name, string server)
        {
            Contact contact = Get(id);
            if (contact == null)
            {
                return false;
            }
            contact.Name = name;
            contact.Server = server;
            return true;
        }
        public bool Delete(string id)
        {
            Contact contact = Get(id);
            if (contact == null)
                return false;

            _contacts.Remove(contact);
            return true;
        }
    }
}