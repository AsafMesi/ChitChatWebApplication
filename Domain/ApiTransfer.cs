using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiTransfer
    {
        public ApiTransfer(string From, string To, string Content)
        {
            from = From;
            to = To;
            content = Content;
        }

        public string from { get; set; }

        public string to { get; set; }

        public string content { get; set; }
    }
}