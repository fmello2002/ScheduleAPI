using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.UseCases.Agendamentos;

namespace ScheduleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController(NovoAgendamento novoAgendamento, BuscarAgendamentosPorClienteId buscarAgendamentosPorUsuarioId) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NovoAgendamentoInput novoAgendamentoInput)
        {
            await novoAgendamento.Execute(novoAgendamentoInput);

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Guid usuarioId)
        {
            var agendamentos = await buscarAgendamentosPorUsuarioId.ExecuteAsync(usuarioId);

            return Ok(agendamentos);
        }
    }
}