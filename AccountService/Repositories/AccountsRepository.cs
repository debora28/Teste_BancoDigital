using Microsoft.EntityFrameworkCore;
using AccountService.Migrations;
using AccountService.Models;

namespace AccountService.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        public readonly Bank01Context DbContext;
        public AccountsRepository(Bank01Context context)
        {
            DbContext = context;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await DbContext.Account.ToListAsync();
        }

        public async Task<Account> GetAccount(int AccountId)
        {
            var account = await DbContext.Account.FindAsync(AccountId);
            if (account == null)
            {
                throw new Exception();
            }
            else
            {
                return account;
            }
        }

        public async Task<Account> CreateAccount(Account account)
        {
            DbContext.Add(account);
            await DbContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            DbContext.Entry(account).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccount(int accountId)
        {
            var account = await DbContext.Account.FindAsync(accountId);
            if (account == null)
            {
                throw new Exception();
            }
            else
            {
                DbContext.Account.Remove(account);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
