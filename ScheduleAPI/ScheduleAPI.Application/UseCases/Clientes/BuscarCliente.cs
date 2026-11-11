using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Exceptions;

namespace ScheduleAPI.Application.UseCases.Clientes
{
    public class BuscarCliente(IClienteRepository repository)
    {
        public async Task<ClienteOutput> ExecuteAsync(Guid id)
        {
            var usuario = await repository.BuscarCliente(id) ?? throw new DomainException("Cliente não encontrado.");
            return new ClienteOutput(usuario.Id, usuario.Nome, usuario.Telefone, usuario.Email.Value, usuario.CPF.Value);
        }
    }
}