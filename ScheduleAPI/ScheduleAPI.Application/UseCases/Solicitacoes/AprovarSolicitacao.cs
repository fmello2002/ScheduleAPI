using ScheduleAPI.Application.Exceptions;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Solicitacoes
{
    public class AprovarSolicitacao(ISolicitacaoRepository solicitacaoRepository, IAgendamentoRepository agendamentoRepository)
    {
        public async Task ExecuteAsync(Guid solicitacaoId)
        {
            var solicitacao = await solicitacaoRepository.BuscarPorId(solicitacaoId)
                   ?? throw new NaoEncontradoException("Solicitação não encontrada.");

            var agendamento = solicitacao.Aprovar();

            await agendamentoRepository.NovoAgendamento(agendamento);
        }
    }
}