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
        public List<Message> Messages { get; set; }

        public Chat(string Usr1, string Usr2)
        {
            Id = ++LastChatNumber;
            LastChatNumber++;
            LastMsgId = 0;
            Username1 = Usr1;
            Username2 = Usr2;
            Messages = new List<Message>();
        }

        public void AddMessage(string Content, string Sender)
        {
            LastMsgId++;
            Message NewMsg = new Message(LastMsgId, Content, Sender);
            Messages.Add(NewMsg);
        }
    }
}