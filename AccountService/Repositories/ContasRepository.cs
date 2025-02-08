using Microsoft.EntityFrameworkCore;
using AccountService.Migrations;
using AccountService.Models;

namespace AccountService.Repositories
{
    public class ContasRepository : IContasRepository
    {
        public readonly BancoContext DbContext;
        public ContasRepository(BancoContext context)
        {
            DbContext = context;
        }
        public async Task<IEnumerable<Conta>> GetContas()
        {
            return await DbContext.Contas.ToListAsync();
        }

        public async Task<Conta> GetConta(int IdConta)
        {
            var conta = await DbContext.Contas.FindAsync(IdConta);
            if (conta == null)
            {
                throw new Exception();
            }
            else
            {
                return conta;
            }
        }

        public async Task<Conta> CreateConta(Conta conta)
        {
            DbContext.Add(conta);
            await DbContext.SaveChangesAsync();
            return conta;
        }

        public async Task<Conta> UpdateConta(Conta conta)
        {
            DbContext.Entry(conta).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return conta;
        }

        public async Task DeleteConta(int idConta)
        {
            var conta = await DbContext.Contas.FindAsync(idConta);
            if (conta == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Contas.Remove(conta);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
