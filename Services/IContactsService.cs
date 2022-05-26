using Domain;

namespace Services
{
    public interface IContactsService
    {
        public Contact Get(string id);
        public bool Create(string id, string name, string server);
        public bool Update(string id, string name, string server);
        public bool Delete(string id);
    }
}