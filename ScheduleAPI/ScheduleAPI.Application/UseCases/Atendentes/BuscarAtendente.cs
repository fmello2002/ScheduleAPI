using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Exceptions;

namespace ScheduleAPI.Application.UseCases
{
    public class BuscarAtendente(IAtendenteRepository repository)
    {
        public async Task<AtendenteOutput> Execute(Guid id)
        {
            var atendente = await repository.BuscarAtendente(id) ?? throw new DomainException("Atendente não encontrado.");
            return new(atendente.Id, atendente.Nome, atendente.Telefone, atendente.Email.Value, atendente.CPF.Value);
        }
    }
}