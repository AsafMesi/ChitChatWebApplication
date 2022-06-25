using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;

namespace Domain
{
    public class MessageWrapper
    {
        [Key]
        public int Id{ get; set; }
        public string Content { get; set; }
        public string Created { get; set; }
        public string SenderUsername { get; set; }

        public MessageWrapper(int id, string content, string senderUsername)
        {
            Id = id;
            Content = content;
            Created = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            SenderUsername = senderUsername;
        }

        public static List<ApiMessage> GetMessages(List<MessageWrapper> messages, string loggedUser)
        {
            int length = messages.Count;
            List <ApiMessage> result = new List <ApiMessage>(new ApiMessage[length]);
            for (int i = 0; i < length; i++)
            {
                MessageWrapper msg = messages[i];
                result[i] = new ApiMessage(msg.Id, msg.Content, msg.Created, (msg.SenderUsername == loggedUser));
            }
            return result;
        }

        public static ApiMessage GetMessage(MessageWrapper msg, string loggedUser)
        {
         ApiMessage res = new ApiMessage(msg.Id, msg.Content, msg.Created, (msg.SenderUsername == loggedUser));
            return res;
        }
    }
}