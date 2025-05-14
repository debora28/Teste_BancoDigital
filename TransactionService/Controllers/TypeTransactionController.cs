using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionService.Models;
using TransactionService.Repositories;

namespace TransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeTransactionController : ControllerBase
    {
        private readonly ITypeTransactionsRepository _typeTransactionsRepository;

        public TypeTransactionController(ITypeTransactionsRepository typeTransactionsRepository)
        {
            _typeTransactionsRepository = typeTransactionsRepository;
        }

        // GETALL: TypeTransactionController
        [HttpGet]
        public async Task<IEnumerable<TypeTransaction>> GetAll()
        {
            return await _typeTransactionsRepository.GetTypeTransactions();
        }

        // GET: TypeTransactionController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeTransaction>> GetOne(int id)
        {
            return await _typeTransactionsRepository.GetTypeTransaction(id);
        }
    }
}
