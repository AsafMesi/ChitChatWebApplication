using Domain;

namespace Services
{
    public interface IUsersService
    {
        public string GetServername();


        public List<User> GetUsers();
        public List<Contact> GetUserContacts(string username);
        public Contact GetUserContact(string username, string contactId);
        public ApiContact GetUser(string id);
        public bool CreateUser(string id, string name, string password);


        public Chat GetChat(string contactId, string userId);
        public bool DeleteChat(string contactId, string userId);
        public void AddChat(string username1, string username2);
        public List<ApiMessage> GetMessages(string contactId, string userId);
        public ApiMessage GetMessage(string contactId, int messageId, string userId);
        public bool AddMessage(string contactId, string content, string userId);
        public bool UpdateMessage(string contactId, int messageId, string content, string userId);
        public bool DeleteMessage(string contactId, int messageId, string userId);
        public bool UpdateLastMessage(string contactId, string Last, string Lastdate, string UserId);

        public string getTokenByUsername(string username);
        public void addToken(string username, string token);
    }
}