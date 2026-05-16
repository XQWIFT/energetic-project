using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.RepositoriesAndServices
{
    public class ClientService(IClientRepository clientRepository) : IClientService
    {
        public Client? FindClientById(Guid Id)
        {
            var client = clientRepository.FindClientById(Id);

            return client;
        }

        public Client? FindClientByINN(string INN)
        {
           var client =  clientRepository.FindClientByInn(INN);

            return client;
        }

        public Dictionary<Guid, Client> GetClientsInDictionary()
        {
            var clients = clientRepository.GetClientsInDictionary();

            return clients;
        }

        public List<Client> LoadActiveClients()
        {
            var clients = clientRepository.LoadActiveClients();

            return clients;
        }

        public void AddClient(Client client)
        {
            clientRepository.AddClient(client);
        }
    }
}