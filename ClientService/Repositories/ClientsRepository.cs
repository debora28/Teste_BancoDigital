using Microsoft.EntityFrameworkCore;
using ClientService.Migrations;
using ClientService.Model;

namespace ClientService.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        public readonly Bank01Context DbContext;
        public ClientsRepository(Bank01Context dbContext)
        {
            DbContext = dbContext;
        }

        async Task<IEnumerable<Client>> IClientsRepository.GetClients()
        {
            return await DbContext.Client.ToListAsync();
        }

        public async Task<Client> GetClient(int id)
        {
            var client = await DbContext.Client.FindAsync(id);
            if (client == null)
            {
                throw new Exception();
            }
            else
            {
                return client;
            }
        }

        public async Task<Client> CreateClient(Client client)
        {
            DbContext.Add(client);
            await DbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClient(Client client)
        {
            if (client == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Entry(client).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                return client;
            }
        }

        public async Task DeleteClient(int id)
        {
            var clientId = await DbContext.Client.FindAsync(id);
            if (clientId == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Client.Remove(clientId);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
