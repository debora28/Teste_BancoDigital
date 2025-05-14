using ClientService.Model;

namespace ClientService.Repositories
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task<Client> CreateClient(Client client);
        Task<Client> UpdateClient(Client client);
        Task DeleteClient(int id);
    }
}
