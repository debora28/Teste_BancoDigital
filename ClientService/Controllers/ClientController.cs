using Microsoft.AspNetCore.Mvc;
using ClientService.CustomValidations;
using ClientService.Repositories;
using ClientService.Model;
using ClientService.Dtos;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IValidateCpfCnpj _validateCpfCnpj;

        public ClientController(IClientsRepository clientsRepository, IValidateCpfCnpj validateCpfCnpj)
        {
            _clientsRepository = clientsRepository;
            _validateCpfCnpj = validateCpfCnpj;
        }

        //GETALL 
        [HttpGet]
        public async Task<IEnumerable<Client>> GetAll()
        {
            var clients = await _clientsRepository.GetClients();
            if (clients == null)
            {
                return (IEnumerable<Client>)NotFound("Não há registros.");
            }
            else
            {
                return clients;
            }
        }

        //GETONE
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetOne(int id)
        {
            var client = await _clientsRepository.GetClient(id);
            if (client == null)
            {
                return NotFound(new { message = $"Usuário de id={id} não encontrado." });
            }
            else
            {
                return client;
            }
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if (client == null) { return BadRequest(); }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_validateCpfCnpj.CpfCnpjIsValid(client.CpfCnpj ?? ""))
                {
                    ModelState.AddModelError("Cpf", "CPF inválido");
                    return BadRequest(ModelState);
                }
                else
                {
                    try
                    {
                        var newClient = await _clientsRepository.CreateClient(client);
                        return CreatedAtAction(nameof(GetAll), new { id = newClient.ClientId }, newClient);
                    }
                    catch
                    {
                        return BadRequest(new { message = "Falha inesperada." });
                    }
                }
            }
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientPutDto clientDto)
        {
            if (clientDto == null) return NotFound();
            else
            {
                try
                {
                    Client client = await _clientsRepository.GetClient(id);
                    client.ClientName = clientDto.ClientName;
                    client.DateBirth = clientDto.DateBirth;
                    await _clientsRepository.UpdateClient(client);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var client = await _clientsRepository.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    if (id == client.ClientId)
                    {
                        await _clientsRepository.DeleteClient(client.ClientId);
                        return Ok();
                    }
                    else
                    {
                        return NotFound(new { message = $"Usuário de id={id} não encontrado." });
                    }
                }
                catch
                {
                    return BadRequest();
                }

            }
        }
    }
}
