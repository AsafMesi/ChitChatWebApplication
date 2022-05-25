using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiUserRegister
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
}