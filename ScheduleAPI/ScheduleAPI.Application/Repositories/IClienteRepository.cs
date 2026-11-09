using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.Repositories
{
    public interface IClienteRepository
    {
        public Task CadastrarCliente(Cliente usuario);

        public Task<Cliente?> BuscarCliente(Guid id);

        public Task<IEnumerable<Cliente>> BuscarClientes();
    }
}