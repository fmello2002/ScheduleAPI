using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.Exceptions;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.UseCases.Solicitacoes
{
    public class NovaSolicitacao(ISolicitacaoRepository repository)
    {
        public async Task ExecutarAsync(NovaSolicitacaoInput input)
        {
            var solicitacaoExistente = await repository.BuscarPorHorarioId(input.HorarioId);

            if (solicitacaoExistente != null)
            {
                throw new SolicitacaoExistenteException("Já existe uma solicitação para este horário.");
            }

            var solicitacao = new Solicitacao(input.HorarioId, input.Observacao, input.ClienteId);

            await repository.NovaSolicitacao(solicitacao);
        }
    }
}