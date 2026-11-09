using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.Repositories
{
    public interface IAgendamentoRepository
    {
        public Task NovoAgendamento(Agendamento agendamento);

        public Task<Agendamento?> ObterAgendamentoPorId(Guid id);

        public Task<IEnumerable<Agendamento>> ObterAgendamentosPorClienteId(Guid usuarioId);
    }
}