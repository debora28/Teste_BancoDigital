using TransactionService.Models;
using Microsoft.EntityFrameworkCore;
using TransactionService.Migrations;

namespace TransactionService.Repositories
{
    public class OperacoesRepository : IOperacoesRepository
    {
        public readonly BancoContext DbContext;
        public OperacoesRepository(BancoContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Operacao>> GetOperacoes()
        {
            return await DbContext.Operacoes.ToListAsync();
        }

        public async Task<Operacao> GetOperacao(int idOperacao)
        {
            var operacao = await DbContext.Operacoes.FindAsync(idOperacao);
            if (operacao == null)
            {
                throw new Exception();
            }
            else
            {
                return operacao;
            }
        }

        public async Task<Operacao> CreateOperacao(Operacao operacao)
        {
            DbContext.Add(operacao);
            await DbContext.SaveChangesAsync();
            return operacao;
        }

        public async Task<Operacao> UpdateOperacao(Operacao operacao)
        {
            DbContext.Entry(operacao).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return operacao;
        }

        public async Task DeleteOperacao(int idOperacao)
        {
            var operacao = await DbContext.Operacoes.FindAsync(idOperacao);
            if (operacao == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Operacoes.Remove(operacao);
                await DbContext.SaveChangesAsync();
            }
        }


    }
}
