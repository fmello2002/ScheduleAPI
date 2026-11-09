using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Exceptions;

namespace ScheduleAPI.Application.UseCases.Horarios
{
    public class BuscarHorario(IHorarioRepository repository)
    {
        public async Task<HorarioOutput> Execute(Guid id)
        {
            var horario = await repository.BuscarHorario(id) ?? throw new DomainException("Horário não encontrado.");
            return new HorarioOutput(horario.Id, new(horario.Dia, horario.Hora), horario.StatusHorario.ToString());
        }
    }
}