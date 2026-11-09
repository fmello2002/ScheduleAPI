using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Horarios
{
    public class BuscarHorariosPorDia(IHorarioRepository repository)
    {
        public async Task<IEnumerable<HorarioOutput>> Execute(DateOnly dia)
        {
            var horarios = await repository.BuscarHorariosPorDia(dia);
            return horarios.Select(h => new HorarioOutput(h.Id, new(h.Dia, h.Hora), h.StatusHorario.ToString()));
        }
    }
}