using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.UseCases.Solicitacoes
{
    public class BuscarSolicitacaoPorId(ISolicitacaoRepository repository)
    {
        public async Task<Solicitacao> ExecutarAsync(Guid clienteId)
        {
            var solicitacoes = await repository.BuscarPorId(clienteId);

            return solicitacoes;
        }
    }
}