using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Application.Repositories
{
    public interface IAtendenteRepository
    {
        public Task CadastrarAtendente(Atendente atendente);

        public Task<Atendente?> BuscarAtendente(Guid id);

        public Task<IEnumerable<Atendente>> BuscarAtendentes();
    }
}