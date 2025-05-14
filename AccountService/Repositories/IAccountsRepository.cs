using AccountService.Models;

namespace AccountService.Repositories
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(int id);
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task DeleteAccount(int id);
    }
}
