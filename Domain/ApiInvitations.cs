using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiInvitations
    {
        public ApiInvitations(string From, string To, string Server)
        {
            from = From;
            to = To;
            server = Server;
        }
        public string from { get; set; }

        public string to { get; set; }

        public string server { get; set; }
    }
}