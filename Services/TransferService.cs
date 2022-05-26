using Domain;

namespace Services
{
    public class TransferService    
    {
        private IContactsService _contactsService;
        public TransferService(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        public MessageWrapper Transfer(string from, string to, string content)
        {
            Chat chat = _contactsService.GetChat(from, to);
            if (chat == null)
            {
                return null;
            }
            MessageWrapper AddedMessage = chat.AddMessage(content, from);
            return AddedMessage;
        }
    }
}