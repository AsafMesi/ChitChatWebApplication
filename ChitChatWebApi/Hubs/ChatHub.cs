using Microsoft.AspNetCore.SignalR;

namespace ChitChatWebApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task getContactUpdate(string userToUpdate)
        {
            Console.WriteLine(userToUpdate);
            await Clients.All.SendAsync("TriggerGetContacts", userToUpdate);
        }
    }
}
