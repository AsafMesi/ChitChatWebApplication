using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        public User(string username,string displayName, string password, string server)
        {
            Id = username;
            Name = displayName;
            Password = password;
            Server = server;
        }


        [Required]
        public string Id  { get; set; }
        [Required]
        public string Name{ get; set; }

        [Required]
        public string Server{ get; set; }

        [Required]
        public string Password { get; set; }
    }
}