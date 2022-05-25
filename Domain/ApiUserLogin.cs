using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiUserLogin
    {
        public string id { get; set; }
        public string password { get; set; }
    }
}