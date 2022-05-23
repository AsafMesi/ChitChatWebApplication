using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Message
    {
        [Key]
        public int Id{ get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string SenderUsername { get; set; }

        public Message(int id, string content, string sender)
        {
            Id = id;
            Content = content;
            SenderUsername = sender;
            Date = DateTime.Now;
        }
    }
}