using ScheduleAPI.Application.DTOs.Response;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Clientes
{
    public class BuscarClientes(IClienteRepository repository)
    {
        public async Task<IEnumerable<ClienteOutput>> ExecuteAsync()
        {
            var usuarios = await repository.BuscarClientes();
            return usuarios.Select(u => new ClienteOutput(u.Id, u.Nome, u.Telefone, u.Email.Value, u.CPF.Value));
        }
    }
}