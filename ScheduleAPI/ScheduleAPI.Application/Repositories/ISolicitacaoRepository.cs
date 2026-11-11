using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.Repositories
{
    public interface ISolicitacaoRepository
    {
        public Task NovaSolicitacao(Solicitacao solicitacao);

        public Task<IEnumerable<Solicitacao>> BuscarSolicitacoesPorClienteId(Guid clienteId);

        public Task<Solicitacao?> BuscarPorId(Guid id);

        public Task<Solicitacao?> BuscarPorHorarioId(Guid id);

        public Task<IEnumerable<Solicitacao>> BuscarSolicitacoesPendentes();

        public Task<IEnumerable<Solicitacao>> BuscarSolicitacoesPorDia(DateOnly dia);
    }
}