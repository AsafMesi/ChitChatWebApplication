using Microsoft.AspNetCore.SignalR;

namespace ChitChatWebApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message, string activeUser, string passiveUser)
        {
            await Clients.All.SendAsync("RecieveMessage",
                $"{activeUser} sent a message to ${passiveUser} that contains the following:\n" +
                $"{message}");
        }
    }
}
