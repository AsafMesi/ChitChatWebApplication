using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Message
    {
        [Key]
        public int Id{ get; set; }
        public string Content { get; set; }
        public string Created { get; set; }
        public bool Sent { get; set; }

        public Message(int id, string content, string created, bool sent)
        {
            Id = id;
            Content = content;
            Created = created;
            Sent = sent;
        }
    }
}