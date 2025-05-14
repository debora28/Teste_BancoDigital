using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Models;
using TransactionService.Repositories;

namespace TransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public TransactionController(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }


        // GETALL: TransactionController
        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _transactionsRepository.GetTransactions();
        }

        // GET: TransactionController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetOne(int id)
        {
            return await _transactionsRepository.GetTransaction(id);
        }

        // GET: TransactionController/Create
        [HttpPost]
        public async Task<ActionResult<Transaction>> Post([FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }
            else
            {
                var newTransaction = await _transactionsRepository.CreateTransaction(transaction);
                return CreatedAtAction(nameof(GetAll), new { id = newTransaction.TransactionId }, newTransaction);
            }
        }

        // GET: TransactionController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Transaction transaction)
        {
            if (transaction == null) { return BadRequest(); }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    try
                    {
                        if (id == transaction.TransactionId)
                        {
                            await _transactionsRepository.UpdateTransaction(transaction);
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
                }
            }
        }

        // DELETE: TransactionController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var transaction = await _transactionsRepository.GetTransaction(id);

            if (transaction == null)
            {
                return NotFound();
            }
            else
            {
                await _transactionsRepository.DeleteTransaction(transaction.TransactionId);
                return NoContent();
            }
        }
    }
}
