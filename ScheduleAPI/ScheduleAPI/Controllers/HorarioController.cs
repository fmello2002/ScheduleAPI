using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.UseCases.Horarios;

namespace ScheduleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioController(BuscarHorarios buscarHorarios, BuscarHorario buscarHorario, BuscarHorariosPorDia buscarHorariosPorDia, CadastrarHorario cadastrarHorario) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHorarios()
        {
            var horarios = await buscarHorarios.ExecuteAsync();
            return Ok(horarios);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetHorario(Guid id)
        {
            var horario = await buscarHorario.ExecuteAsync(id);
            return Ok(horario);
        }

        [HttpGet("dia/{dia}")]
        public async Task<IActionResult> GetHorariosPorDia(DateOnly dia)
        {
            var horarios = await buscarHorariosPorDia.ExecuteAsync(dia);
            return Ok(horarios);
        }

        [HttpPost]
        public async Task<IActionResult> PostHorario([FromBody] CadastrarHorarioInput input)
        {
            await cadastrarHorario.ExecuteAsync(input);
            return Created();
        }
    }
}