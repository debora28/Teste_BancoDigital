using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Models;
using TransactionService.Repositories;

namespace TransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacaoController : ControllerBase
    {
        private readonly IOperacoesRepository _operacoesRepository;

        public OperacaoController(IOperacoesRepository operacoesRepository)
        {
            _operacoesRepository = operacoesRepository;
        }


        // GETALL: OperacaoController
        [HttpGet]
        public async Task<IEnumerable<Operacao>> GetAll()
        {
            return await _operacoesRepository.GetOperacoes();
        }

        // GET: OperacaoController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operacao>> GetOne(int id)
        {
            return await _operacoesRepository.GetOperacao(id);
        }

        // GET: OperacaoController/Create
        [HttpPost]
        public async Task<ActionResult<Operacao>> Post([FromBody] Operacao operacao)
        {
            if (operacao == null)
            {
                return BadRequest();
            }
            else
            {
                var operacaoNova = await _operacoesRepository.CreateOperacao(operacao);
                return CreatedAtAction(nameof(GetAll), new { id = operacaoNova.IdOperacao }, operacaoNova);
            }
        }

        // GET: OperacaoController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Operacao operacao)
        {
            if (operacao == null) { return BadRequest(); }
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
                        if (id == operacao.IdOperacao)
                        {
                            await _operacoesRepository.UpdateOperacao(operacao);
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

        // DELETE: OperacaoController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var operacao = await _operacoesRepository.GetOperacao(id);

            if (operacao == null)
            {
                return NotFound();
            }
            else
            {
                await _operacoesRepository.DeleteOperacao(operacao.IdOperacao);
                return NoContent();
            }
        }
    }
}
