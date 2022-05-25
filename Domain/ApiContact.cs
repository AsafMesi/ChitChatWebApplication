using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiContact
    {
        public ApiContact(string Id, string Name, string Server)
        {
            id = Id;
            name = Name;
            server = Server;
        }

        public string id { get; set; }

        public string name { get; set; }

        public string server { get; set; }
    }
}