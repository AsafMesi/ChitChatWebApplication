using Domain;

namespace Services
{
    public class UsersService
    {
        // gigity, master of disguise, Loretta where are you?

        private static Dictionary<string, List<Contact>> AllUsers =
             new Dictionary<string, List<Contact>>()
             {
                {"peter", new List<Contact>(){
                    new Contact("quagmire1", "Quagmire", "localhost:7266", null, null),
                    new Contact("joe1", "Joe", "localhost:7266", null, null),
                    new Contact("cleveland1", "Cleveland", "localhost:7266", null, null)
                     }
                 },
                {"quagmire1", new List<Contact>(){
                    new Contact("peter1", "Peter", "localhost:7266", null, null)
                     }
                 },
                {"joe1", new List<Contact>(){
                    new Contact("peter1", "Peter", "localhost:7266", null, null)
                     }
                 },
                {"cleveland1", new List<Contact>(){
                    new Contact("peter1", "Peter", "localhost:7266", null, null)
                     }
                 }
             };

        private static List<Chat> AllChats = new List<Chat>()
        {
            new Chat("peter", "quagmire1"),
            new Chat("peter", "joe1"),
            new Chat("peter", "cleveland1")
        };


        public List<Contact> GetAll(string LoggedUser)
        {
            if (AllUsers.ContainsKey(LoggedUser))
                return AllUsers[LoggedUser];
            return null;
        }
        public Contact Get(string id, string LoggedUser)
        {
            List<Contact> contacts = GetAll(LoggedUser);
            if (contacts == null)
                return null;

            Contact contact = contacts.Find(x => x.Id == id);
            return contact;
        }
        public bool Add(string id, string name, string server, string LoggedUser)
        {
            Contact contact = Get(id, LoggedUser);
            if (contact == null) 
            {
                Contact NewContact = new Contact(id, name, server, null, null);
                AllUsers[LoggedUser].Add(NewContact);
                AllChats.Add(new Chat(LoggedUser, id));
                // should use invitioans here ?
                return true;
            }
            return false;
        }
        public bool Update(string id, string name, string server, string LoggedUser)
        {
            Contact contact = Get(id, LoggedUser);
            if (contact == null)
                return false;

            contact.Name = name;
            contact.Server = server;
            return true;
        }
        public bool Delete(string id, string LoggedUser)
        {
            Contact contact = Get(id, LoggedUser);
            if (contact == null)
                return false;

            Chat ToDelete = GetChat(id, LoggedUser);
            AllUsers[LoggedUser].Remove(contact);
            AllChats.Remove(ToDelete);
            return true;
        }

        public Chat GetChat(string id, string LoggedUser)
        {
            Chat chat = null;
            foreach (Chat x in AllChats)
            {
                if ((x.Username1 == LoggedUser && x.Username2 == id) ||
                    (x.Username1 == id && x.Username2 == LoggedUser))
                {
                    chat = x;
                    break;
                }
            }
            return chat;
        }
        public List<Message> GetMessages(string id, string LoggedUser) 
        {
            Chat chat = GetChat(id, LoggedUser);
            if (chat == null)
            {
                return null;
            }
            return chat.Messages;
        }
        public bool AddMessage(string id, string content, string LoggedUser) 
        {
            Chat chat = GetChat(id, LoggedUser);
            if (chat == null)
            {
                return false;
            }
            // add the message and get ref to it.
            Message AddedMessage = chat.AddMessage(content, true);
            UpdateLastMessage(id, AddedMessage.Content, AddedMessage.Created, LoggedUser);
            // should use transfer ?
            return true;
        }
        public Message GetMessage(string id, int id2, string LoggedUser) 
        {
            Chat chat = GetChat(id, LoggedUser);
            if (chat == null)
            {
                return null;
            }
            Message message = chat.Messages.Find(x => x.Id == id2);
            return message;
        }
        public bool UpdateMessage(string id, int id2, string content, string LoggedUser)
        {
            Message message = GetMessage(id, id2, LoggedUser);
            if (message == null)
            {
                return false;
            }
            message.Content = content; // need to check if it is the last msg and if so update the contact.
            return true;
        }
        public bool DeleteMessage(string id, int id2, string LoggedUser)
        {
            Chat chat = GetChat(id, LoggedUser);
            if (chat == null)
            {
                return false;
            }
            Message message = chat.Messages.Find(x => x.Id == id2);
            if (message != null)
            {
                chat.Messages.Remove(message); // need to get new last msg to update the contact.
                return true;
            }
            return false;
        }

        private bool UpdateLastMessage(string id, string Last, string Lastdate, string LoggedUser)
        {
            Contact ContactToUpdate = Get(id, LoggedUser);
            if (ContactToUpdate == null)
            {
                return false;
            }
            ContactToUpdate.Last = Last;
            ContactToUpdate.Lastdate = Lastdate;
            return true;
        }
    }
}