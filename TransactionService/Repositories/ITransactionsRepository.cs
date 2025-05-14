using TransactionService.Models;

namespace TransactionService.Repositories
{
    public interface ITransactionsRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<Transaction> GetTransaction(int id);
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<Transaction> UpdateTransaction(Transaction transaction);
        Task DeleteTransaction(int id);
    }
}
