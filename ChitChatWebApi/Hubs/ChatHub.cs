using Microsoft.AspNetCore.SignalR;

//Hub for SignalR
namespace ChitChatWebApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task getContactUpdate()
        {
            //Console.WriteLine(userToUpdate);
            if (Clients != null)
            {
                await Clients.All.SendAsync("TriggerGetContacts");//, userToUpdate);
            }
        }
    }
}
