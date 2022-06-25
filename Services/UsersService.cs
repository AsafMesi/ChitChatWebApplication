using Domain;

namespace Services
{
    public class UsersService : IUsersService
    {
        // static data:
        private static string servername = "localhost:5241";

        private static List<User> RegisteredUsers = new List<User>()
        {
            new User("peter1", "Peter", "12345678!a", "localhost:5241"),
            new User("quagmire1", "Quagmire", "12345678!a", "localhost:5241"),
            new User("joe1", "Joe", "12345678!a", "localhost:5241"),
            new User("cleveland1", "Cleveland", "12345678!a", "localhost:5241"),

        };
        private static Dictionary<string, List<Contact>> AllUsers = new()
        {
                   {"peter1", new List<Contact>(){
                       new Contact("quagmire1", "Quagmire", "localhost:5241", null, null),
                       new Contact("joe1", "Joe", "localhost:5241", null, null),
                       new Contact("cleveland1", "Cleveland", "localhost:5241", null, null)
                        }
                    },
                   {"quagmire1", new List<Contact>(){
                       new Contact("peter1", "Peter", "localhost:5241", null, null)
                        }
                    },
                   {"joe1", new List<Contact>(){
                       new Contact("peter1", "Peter", "localhost:5241", null, null)
                        }
                    },
                   {"cleveland1", new List<Contact>(){
                       new Contact("peter1", "Peter", "localhost:5241", null, null)
                        }
                    }
        };
        private static List<Chat> AllChats = new List<Chat>()
        {
            new Chat("peter1", "quagmire1"),
            new Chat("peter1", "joe1"),
            new Chat("peter1", "cleveland1")
        };
        public string GetServername()
        {
            return servername;
        }


        // Users functions:
        public List<User> GetUsers()
        {
            return RegisteredUsers;
        }
        public List<Contact> GetUserContacts(string username)
        {
            if (AllUsers.ContainsKey(username))
                return AllUsers[username];
            return null;
        }
        public Contact GetUserContact(string username, string contactId)
        {
            List<Contact> contacts = GetUserContacts(username);
            Contact contact = contacts.Find(x => x.Id == contactId);
            return contact;
        }
        public ApiContact GetUser(string id)
        {
            User user = RegisteredUsers.Find(x => x.Id == id);
            if (user == null)
                return null;
            return new ApiContact(user.Id, user.Name, user.Server);
        }
        public bool CreateUser(string id, string name, string password)
        {
            var newUser = RegisteredUsers.Find(x => x.Id == id);
            if (newUser != null)
            {
                return false;
            }
            RegisteredUsers.Add(new User(id, name, password, GetServername()));
            AllUsers[id] = new List<Contact>();
            return true;
        }
        

        // Chat functions:
        public Chat GetChat(string contactId, string userId)
        {
            Chat chat = null;
            foreach (Chat x in AllChats)
            {
                if ((x.Username1 == userId && x.Username2 == contactId) ||
                    (x.Username1 == contactId && x.Username2 == userId))
                {
                    chat = x;
                    break;
                }
            }
            return chat;
        }
        public bool DeleteChat(string contactId, string userId)
        {
            Chat ToDelete = GetChat(contactId, userId);
            if (ToDelete == null)
            {
                return false;
            }
            AllChats.Remove(ToDelete);
            return true;
        }
        public void AddChat(string username1, string username2)
        {
            AllChats.Add(new Chat(username1, username2));
        }
        public List<Message> GetMessages(string contactId, string userId)
        {
            Chat chat = GetChat(contactId, userId);
            if (chat == null)
            {
                return null;
            }
            return MessageWrapper.GetMessages(chat.Messages, userId);
        }
        public Message GetMessage(string contactId, int messageId, string userId)
        {
            List<Message> messages = GetMessages(contactId, userId);
            Message message = messages.Find(x => x.Id == messageId);
            return message;
        }
        public bool AddMessage(string contactId, string content, string userId)
        {
            Chat chat = GetChat(contactId, userId);
            if (chat == null)
            {
                return false;
            }
            MessageWrapper AddedMessage = chat.AddMessage(content, userId);
            if (AddedMessage == null)
            {
                return false;
            }
            UpdateLastMessage(contactId, AddedMessage.Content, AddedMessage.Created, userId);
            return true;
        }
        public bool UpdateMessage(string contactId, int messageId, string content, string userId)
        {
            Message message = GetMessage(contactId, messageId, userId);
            if (message == null)
            {
                return false;
            }
            message.Content = content; // need to update last msg ?
            return true;
        }
        public bool UpdateLastMessage(string contactId, string Last, string Lastdate, string UserId)
        {
            Contact ContactToUpdate = GetUserContact(contactId, UserId);
            if (ContactToUpdate == null)
            {
                return false;
            }
            ContactToUpdate.Last = Last;
            ContactToUpdate.Lastdate = Lastdate;
            return true;
        }
        public bool DeleteMessage(string contactId, int messageId, string userId)
        {
            Chat chat = GetChat(contactId, userId);
            if (chat == null)
            {
                return false;
            }
            MessageWrapper message = chat.Messages.Find(x => x.Id == messageId);
            if (message != null)
            {
                chat.Messages.Remove(message); // need to update last msg ?
                return true;
            }
            return false;
        }
    }
}        