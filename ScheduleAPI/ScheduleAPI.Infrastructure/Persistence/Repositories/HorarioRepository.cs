using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Infrastructure.Persistence.Repositories
{
    public class HorarioRepository(ScheduleDbContext context) : IHorarioRepository
    {
        public async Task<Horario?> BuscarHorario(Guid id)
        {
            var horario = await context.Horarios.FindAsync(id);
            return horario;
        }

        public Task<IEnumerable<Horario>> BuscarHorarios()
        {
            var horarios = context.Horarios.AsNoTracking().ToList();
            return Task.FromResult<IEnumerable<Horario>>(horarios);
        }

        public async Task<IEnumerable<Horario>> BuscarHorariosPorDia(DateOnly dia)
        {
            var horarios = await context.Horarios.AsNoTracking().Where(h => h.Dia == dia).ToListAsync();
            return horarios;
        }

        public async Task CadastrarHorario(Horario horario)
        {
            await context.Horarios.AddAsync(horario);
            await context.SaveChangesAsync();
        }
    }
}