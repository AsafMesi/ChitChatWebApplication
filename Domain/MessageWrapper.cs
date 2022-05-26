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

        public static List<Message> GetMessages(List<MessageWrapper> messages, string loggedUser)
        {
            int length = messages.Count;
            List <Message> result = new List <Message>(new Message[length]);
            for (int i = 0; i < length; i++)
            {
                MessageWrapper msg = messages[i];
                result[i] = new Message(msg.Id, msg.Content, msg.Created, (msg.SenderUsername == loggedUser));
            }
            return result;
        }

        public static Message GetMessage(MessageWrapper msg, string loggedUser)
        {
         Message res = new Message(msg.Id, msg.Content, msg.Created, (msg.SenderUsername == loggedUser));
            return res;
        }
    }
}