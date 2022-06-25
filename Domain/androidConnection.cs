using System.ComponentModel.DataAnnotations;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;

using Google.Apis.Auth.OAuth2;

namespace Domain
{
    public class androidConnection
    {

        private static FirebaseMessaging messaging = null;

        public androidConnection()
        {
            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.
                FromFile("private_key.json").
                CreateScoped("https://www.googleapis.com/auth/firebase.messaging")
            });
            messaging = FirebaseMessaging.GetMessaging(app);
        }

        private Message CreateNotification(string to, string from, string title, string notificationBody, string token)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["to"] = to;
            data["from"] = from;
            data["text"] = notificationBody;
            return new Message()
            {
                Token = token,
                Notification = new Notification()
                {
                    Body = notificationBody,
                    Title = title,
                },
                Data = data
            };
        }

        public async Task SendNotification(string username, string userchat, string token, string title, string body)
        {
            await messaging.SendAsync(CreateNotification(username, userchat, title, body, token));
        }
    }
}

