using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases
{
    public class BuscarAtendentes(IAtendenteRepository repository)
    {
        public async Task<IEnumerable<AtendenteOutput>> ExecuteAsync()
        {
            var atendentes = await repository.BuscarAtendentes();
            return atendentes.Select(a => new AtendenteOutput(a.Id, a.Nome, a.Telefone, a.Email.Value, a.CPF.Value));
        }
    }
}