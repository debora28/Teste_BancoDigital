using TransactionService.Models;

namespace TransactionService.Repositories
{
    public interface ITypeTransactionsRepository
    {
        Task<IEnumerable<TypeTransaction>> GetTypeTransactions();
        Task<TypeTransaction> GetTypeTransaction(int id);
    }
}
