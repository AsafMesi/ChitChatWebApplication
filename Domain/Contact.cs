using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Contact
    {
        public Contact(string Username, string DisplayName, string ServerName, string? LastMsg, DateTime? LastMsgDate)
        {
            Id = Username;
            Name = DisplayName;
            Server = ServerName;
            Last = LastMsg;
            Lastdate = LastMsgDate;
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Server { get; set; }

        public string? Last { get; set; }

        public DateTime? Lastdate { get; set; }
    }
}