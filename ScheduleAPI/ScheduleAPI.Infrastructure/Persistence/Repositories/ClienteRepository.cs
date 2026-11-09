using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository(ScheduleDbContext context) : IClienteRepository
    {
        public async Task<Cliente?> BuscarCliente(Guid id)
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> BuscarClientes()
        {
            return await context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task CadastrarCliente(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
        }
    }
}