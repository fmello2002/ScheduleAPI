using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.UseCases;

namespace ScheduleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendenteController(CadastrarAtendente cadastrarAtendente, BuscarAtendente buscarAtendente, BuscarAtendentes buscarAtendentes) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTodosAsync()
        {
            var atendentes = await buscarAtendentes.ExecuteAsync();

            return Ok(atendentes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPorIdAsync(Guid id)
        {
            var atendente = await buscarAtendente.ExecuteAsync(id);
            return Ok(atendente);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarAtendenteInput cadastrarAtendenteInput)
        {
            await cadastrarAtendente.ExecuteAsync(cadastrarAtendenteInput);
            return Created();
        }
    }
}