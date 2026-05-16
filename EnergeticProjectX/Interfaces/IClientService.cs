using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    public interface IClientService
    {
        public Client? FindClientById(Guid Id);

        public Client? FindClientByINN(string INN);

        List<Client> LoadActiveClients();

        Dictionary<Guid, Client> GetClientsInDictionary();

        public void AddClient(Client client);
    }
}
