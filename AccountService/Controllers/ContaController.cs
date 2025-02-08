using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccountService.Models;
using AccountService.Repositories;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContasRepository _contasRepository;

        public ContaController(IContasRepository contasRepository)
        {
            _contasRepository = contasRepository;
        }

        // GET: ContaController
        [HttpGet]
        public async Task<IEnumerable<Conta>> GetAll()
        {
            return await _contasRepository.GetContas();
        }

        // GET: ContaController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetOne(int id)
        {
            return await _contasRepository.GetConta(id);
        }

        // GET: ContaController/Create
        [HttpPost]
        public async Task<ActionResult<Conta>> Post([FromBody] Conta conta)
        {
            if (conta == null)
            {
                return BadRequest();
            }
            else
            {
                var contaNova = await _contasRepository.CreateConta(conta);
                return CreatedAtAction(nameof(GetAll), new {id = contaNova.IdConta }, contaNova);
            }
        }

        // GET: ContaController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Conta conta)
        {
            if (conta == null) { return BadRequest(); }
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
                        if (id == conta.IdConta)
                        {
                            await _contasRepository.UpdateConta(conta);
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

        // DELETE: ContaController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var conta = await _contasRepository.GetConta(id);

            if (conta == null)
            {
                return NotFound();
            }
            else
            {
                await _contasRepository.DeleteConta(conta.IdConta);
                return NoContent();
            }
        }
    }
}
