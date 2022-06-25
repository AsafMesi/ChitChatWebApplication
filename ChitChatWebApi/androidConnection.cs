using System.ComponentModel.DataAnnotations;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;

using Google.Apis.Auth.OAuth2;

namespace ChitChatWebApi
{
    public class androidConnection
    {

        private static FirebaseMessaging messaging = null;
        private static FirebaseAdmin.FirebaseApp app;
        private static androidConnection androidCon = null;

        public static androidConnection getInstance()
        {
            if (androidCon == null)
            {
                androidCon = new androidConnection();
            }
            return androidCon;
        }

        private androidConnection()
        {
             app = FirebaseApp.Create(new AppOptions()
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
            data["tto"] = to;
            data["tfrom"] = from;
            data["tcontent"] = notificationBody;
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
            var m = CreateNotification(username, userchat, title, body, token);
            await messaging.SendAsync(m);
        }
    }
}

