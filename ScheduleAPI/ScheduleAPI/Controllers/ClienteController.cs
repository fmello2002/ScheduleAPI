using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.UseCases.Clientes;

namespace ScheduleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(CadastrarCliente cadastrarCliente, BuscarCliente BuscarCliente, BuscarClientes BuscarClientes) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarClienteInput cadastrarClienteInput)
        {
            await cadastrarCliente.ExecuteAsync(cadastrarClienteInput);

            return Created();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPorIdAsync(Guid id)
        {
            var cliente = await BuscarCliente.ExecuteAsync(id);
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosAsync()
        {
            var clientes = await BuscarClientes.ExecuteAsync();
            return Ok(clientes);
        }
    }
}