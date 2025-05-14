using TransactionService.Models;
using Microsoft.EntityFrameworkCore;
using TransactionService.Migrations;

namespace TransactionService.Repositories
{
    public class TypeTransactionsRepository : ITypeTransactionsRepository
    {
        public readonly Bank01Context DbContext;
        public TypeTransactionsRepository(Bank01Context dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<TypeTransaction>> GetTypeTransactions()
        {
            return await DbContext.TypeTransaction.ToListAsync();
        }

        public async Task<TypeTransaction> GetTypeTransaction(int idTypeTransaction)
        {
            var typeTransaction = await DbContext.TypeTransaction.FindAsync(idTypeTransaction);
            if (typeTransaction == null)
            {
                throw new Exception();
            }
            else
            {
                return typeTransaction;
            }
        }

    }
}
