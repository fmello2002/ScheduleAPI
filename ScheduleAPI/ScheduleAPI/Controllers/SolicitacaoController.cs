using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.UseCases.Solicitacoes;

namespace ScheduleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitacaoController(NovaSolicitacao novaSolicitacao,
                                       BuscarSolicitacoesPorClienteId buscarSolicitacoesPorClienteId,
                                       BuscarSolicitacoesPorDia buscarSolicitacoesPorDia,
                                       BuscarSolicitacoesPendentes buscarSolicitacoesPendentes,
                                       AprovarSolicitacao aprovarSolicitacao) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> NovaSolicitacao([FromBody] NovaSolicitacaoInput solicitacao)
        {
            await novaSolicitacao.ExecutarAsync(solicitacao);
            return Created();
        }

        [HttpPost("Aprovar/{id}")]
        public async Task<IActionResult> Aprovar(Guid id)
        {
            await aprovarSolicitacao.ExecuteAsync(id);
            return NoContent();
        }

        [HttpGet("Cliente/{id}")]
        public async Task<IActionResult> BuscarSolicitacaoPorClienteId(Guid id)
        {
            var solicitacao = await buscarSolicitacoesPorClienteId.ExecutarAsync(id);
            return Ok(solicitacao);
        }

        [HttpGet("Dia/{dia}")]
        public async Task<IActionResult> BuscarSolicitacaoPorDia(DateOnly dia)
        {
            var solicitacao = await buscarSolicitacoesPorDia.ExecutarAsync(dia);
            return Ok(solicitacao);
        }

        [HttpGet("Pendentes")]
        public async Task<IActionResult> BuscarSolicitacoesPendentes()
        {
            var solicitacoes = await buscarSolicitacoesPendentes.ExecutarAsync();
            return Ok(solicitacoes);
        }
    }
}