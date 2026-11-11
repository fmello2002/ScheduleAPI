using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Solicitacoes
{
    public class BuscarSolicitacoesPorDia(ISolicitacaoRepository repository)
    {
        public async Task<IEnumerable<SolicitacaoOutPut>> ExecutarAsync(DateOnly dia)
        {
            var solicitacoes = await repository.BuscarSolicitacoesPorDia(dia);
            return solicitacoes.Select(s => new SolicitacaoOutPut(s.Id, new DateTime(s.Horario.Dia, s.Horario.Hora), s.Cliente.Nome, s.Status.ToString(), s.Observacao));
        }
    }
}