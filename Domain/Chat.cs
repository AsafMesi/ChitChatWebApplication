using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Chat
    {
        private static int LastChatNumber;
        private int LastMsgId;

        [Key]
        public int Id { get; set; }
        public string Username1 { get; set; }
        public string Username2 { get; set; }
        public List<MessageWrapper> Messages { get; set; }

        public Chat(string Usr1, string Usr2)
        {
            Id = ++LastChatNumber;
            LastChatNumber++;
            LastMsgId = 0;
            Username1 = Usr1;
            Username2 = Usr2;
            Messages = new List<MessageWrapper>();
        }

        // return the Id of the added msg.
        public MessageWrapper AddMessage(string Content, string loggedUser)
        {
            LastMsgId++;
            MessageWrapper NewMsg = new MessageWrapper(LastMsgId, Content, loggedUser);
            Messages.Add(NewMsg);
            return NewMsg;
        }

        public Message GetMessage(int id, string loggedUser)
        {
            MessageWrapper message = Messages.Find(x => x.Id == id);
            if (message == null)
                return null;
            return MessageWrapper.GetMessage(message, loggedUser);
        }


    }
}