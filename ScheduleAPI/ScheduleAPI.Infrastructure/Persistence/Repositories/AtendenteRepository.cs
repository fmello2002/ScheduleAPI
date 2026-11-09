using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Infrastructure.Persistence.Repositories
{
    public class AtendenteRepository(ScheduleDbContext context) : IAtendenteRepository
    {
        public async Task<Atendente?> BuscarAtendente(Guid id)
        {
            var atendente = await context.Atendentes.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

            return atendente;
        }

        public async Task<IEnumerable<Atendente>> BuscarAtendentes()
        {
            return await context.Atendentes.AsNoTracking().ToListAsync();
        }

        public async Task CadastrarAtendente(Atendente atendente)
        {
            await context.Atendentes.AddAsync(atendente);
            await context.SaveChangesAsync();
        }
    }
}