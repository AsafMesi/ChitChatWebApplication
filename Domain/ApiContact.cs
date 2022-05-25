using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiContact
    {
        public string id { get; set; }

        public string name { get; set; }

        public string server { get; set; }
    }
}