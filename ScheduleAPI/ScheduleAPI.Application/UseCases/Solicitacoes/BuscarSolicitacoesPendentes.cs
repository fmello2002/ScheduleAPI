using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Solicitacoes
{
    public class BuscarSolicitacoesPendentes(ISolicitacaoRepository repository)
    {
        public async Task<IEnumerable<SolicitacaoOutPut>> ExecutarAsync()
        {
            var solicitacoes = await repository.BuscarSolicitacoesPendentes();
            return solicitacoes.Select(s => new SolicitacaoOutPut(s.Id, new DateTime(s.Horario.Dia, s.Horario.Hora), s.Cliente.Nome, s.Status.ToString(), s.Observacao));
        }
    }
}