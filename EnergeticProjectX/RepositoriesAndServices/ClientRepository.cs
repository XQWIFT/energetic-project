using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Objects;

namespace EnergeticProjectX.RepositoriesAndServices
{
    public class ClientRepository(ApplicationContextDB db) : IClientRepository
    {
        public Client? FindClientById(Guid Id)
        {
            var client = db.Clients.FirstOrDefault(u => u.Client_Id == Id);

            return client;
        }

        public Client? FindClientByInn(string INN)
        {
            var client = db.Clients.FirstOrDefault(u => u.INN == INN );

            return client;
        }

        public List<Client> LoadActiveClients()
        {
            var clients = db.Clients.Where(c => c.Status == Status.Active).ToList();

            return clients;

        }

        public Dictionary<Guid, Client> GetClientsInDictionary()
        {
            var clients = db.Clients.ToDictionary(c => c.Client_Id, c => c);
            return clients;
        }

        public void AddClient(Client client)
        {
            db.Clients.Add(client);
        }
    }
}
