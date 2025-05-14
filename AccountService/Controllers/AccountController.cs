using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccountService.Models;
using AccountService.Repositories;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountController(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        // GET: AccountController
        [HttpGet]
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _accountsRepository.GetAccounts();
        }

        // GET: AccountController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetOne(int id)
        {
            return await _accountsRepository.GetAccount(id);
        }

        // GET: AccountController/Create
        [HttpPost]
        public async Task<ActionResult<Account>> Post([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            else
            {
                var newAccount = await _accountsRepository.CreateAccount(account);
                return CreatedAtAction(nameof(GetAll), new {id = newAccount.AccountId }, newAccount);
            }
        }

        // GET: AccountController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Account account)
        {
            if (account == null) { return BadRequest(); }
            else
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                //else
                //{
                    try
                    {
                        if (id == account.AccountId)
                        {
                            await _accountsRepository.UpdateAccount(account);
                            return Ok();
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    catch
                    {
                        return BadRequest();
                    }
                //}
            }
        }

        // DELETE: AccountController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var account = await _accountsRepository.GetAccount(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                await _accountsRepository.DeleteAccount(account.AccountId);
                return NoContent();
            }
        }
    }
}
