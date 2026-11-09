using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Horarios
{
    public class BuscarHorarios(IHorarioRepository repository)
    {
        public async Task<IEnumerable<HorarioOutput>> Execute()
        {
            var horarios = await repository.BuscarHorarios();
            return horarios.Select(h => new HorarioOutput(h.Id, new(h.Dia, h.Hora), h.StatusHorario.ToString()));
        }
    }
}