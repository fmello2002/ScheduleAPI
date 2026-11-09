using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.Repositories
{
    public interface IHorarioRepository
    {
        public Task CadastrarHorario(Horario horario);

        public Task<IEnumerable<Horario>> BuscarHorarios();

        public Task<Horario?> BuscarHorario(Guid id);

        public Task<IEnumerable<Horario>> BuscarHorariosPorDia(DateOnly dia);
    }
}