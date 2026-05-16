using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    public interface IClientRepository
    {
        public Client? FindClientById(Guid Id);

        public Client? FindClientByInn(string INN);

        public List<Client> LoadActiveClients();

        public Dictionary<Guid, Client> GetClientsInDictionary();

        public void AddClient(Client client);
    }
}