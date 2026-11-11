using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.UseCases.Horarios
{
    public class CadastrarHorario(IHorarioRepository repository)
    {
        public async Task ExecuteAsync(CadastrarHorarioInput horarioInput)
        {
            var horario = new Horario(horarioInput.Horario);

            await repository.CadastrarHorario(horario);
        }
    }
}