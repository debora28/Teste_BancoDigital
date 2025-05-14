using TransactionService.Models;
using Microsoft.EntityFrameworkCore;
using TransactionService.Migrations;

namespace TransactionService.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        public readonly Bank01Context DbContext;
        public TransactionsRepository(Bank01Context dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await DbContext.Transaction.ToListAsync();
        }

        public async Task<Transaction> GetTransaction(int idTransaction)
        {
            var transaction = await DbContext.Transaction.FindAsync(idTransaction);
            if (transaction == null)
            {
                throw new Exception();
            }
            else
            {
                return transaction;
            }
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            DbContext.Add(transaction);
            await DbContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            DbContext.Entry(transaction).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return transaction;
        }

        public async Task DeleteTransaction(int idTransaction)
        {
            var transaction = await DbContext.Transaction.FindAsync(idTransaction);
            if (transaction == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Transaction.Remove(transaction);
                await DbContext.SaveChangesAsync();
            }
        }


    }
}
