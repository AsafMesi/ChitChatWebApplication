using Domain;

namespace Services
{
    public interface IContactsService
    {
        public string GetServername();
        public List<Contact> GetAll(string LoggedUser);
        public Contact Get(string id, string LoggedUser);
        public bool Add(string id, string name, string server, string LoggedUser);
        public bool Update(string id, string name, string server, string LoggedUser);
        public bool Delete(string id, string LoggedUser);
        public List<Message> GetMessages(string id, string LoggedUser);
        public bool AddMessage(string id, string content, string LoggedUser);
        public Message GetMessage(string id, int id2, string LoggedUser);
        public bool UpdateMessage(string id, int id2, string content, string LoggedUser);
        public bool DeleteMessage(string id, int id2, string LoggedUser);
        public List<User> GetUsers();
        public bool AddUser(User user);
    }
}