using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Agendamentos
{
    public class BuscarAgendamentosPorClienteId(IAgendamentoRepository repository)
    {
        public async Task<IEnumerable<AgendamentoOutput>> ExecuteAsync(Guid usuarioId)
        {
            var agendamentos = await repository.ObterAgendamentosPorClienteId(usuarioId);

            return agendamentos.Select(a => new AgendamentoOutput(new(a.Horario.Dia, a.Horario.Hora), a.Observacao, a.Cliente.Nome));
        }
    }
}