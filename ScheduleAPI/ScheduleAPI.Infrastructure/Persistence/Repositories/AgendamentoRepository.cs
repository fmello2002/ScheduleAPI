using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Infrastructure.Persistence.Repositories
{
    public class AgendamentoRepository(ScheduleDbContext context) : IAgendamentoRepository
    {
        public async Task NovoAgendamento(Agendamento agendamento)
        {
            await context.Agendamentos.AddAsync(agendamento);
            await context.SaveChangesAsync();
        }

        public Task<Agendamento?> ObterAgendamentoPorId(Guid id)
        {
            return context.Agendamentos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Agendamento>> ObterAgendamentosPorClienteId(Guid clienteId)
        {
            return context.Agendamentos.AsNoTracking().Include(a => a.Cliente).Where(a => a.ClienteId == clienteId);
        }
    }
}