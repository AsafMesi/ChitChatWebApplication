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

        public Message(int id, string content, bool sent)
        {
            Id = id;
            Content = content;
            Created = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            Sent = sent;
        }
    }
}