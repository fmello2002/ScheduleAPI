using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Infrastructure.Persistence.Repositories
{
    public class SolicitacaoRepository(ScheduleDbContext dbContext) : ISolicitacaoRepository
    {
        public async Task<Solicitacao?> BuscarPorHorarioId(Guid id)
        {
            return await dbContext.Solicitacoes
                                   .Include(s => s.Horario)
                                   .Include(s => s.Cliente)
                                   .FirstOrDefaultAsync(s => s.HorarioId == id);
        }

        public async Task<Solicitacao?> BuscarPorId(Guid id)
        {
            return await dbContext.Solicitacoes
                                   .Include(s => s.Horario)
                                   .Include(s => s.Cliente)
                                   .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Solicitacao>> BuscarSolicitacoesPendentes()
        {
            return await dbContext.Solicitacoes.AsNoTracking()
                                               .Include(s => s.Horario)
                                               .Include(s => s.Cliente)
                                               .Where(s => s.Status == StatusSolicitacao.Pendente)
                                               .ToListAsync();
        }

        public async Task<IEnumerable<Solicitacao>> BuscarSolicitacoesPorClienteId(Guid clienteId)
        {
            return await dbContext.Solicitacoes.AsNoTracking()
                                               .Include(s => s.Horario)
                                               .Include(s => s.Cliente)
                                               .Where(s => s.ClienteId == clienteId)
                                               .ToListAsync();
        }

        public async Task<IEnumerable<Solicitacao>> BuscarSolicitacoesPorDia(DateOnly dia)
        {
            return await dbContext.Solicitacoes.AsNoTracking()
                                               .Include(s => s.Horario)
                                               .Include(s => s.Cliente)
                                               .Where(s => s.Horario.Dia == dia)
                                               .ToListAsync();
        }

        public async Task NovaSolicitacao(Solicitacao solicitacao)
        {
            await dbContext.Solicitacoes.AddAsync(solicitacao);
            await dbContext.SaveChangesAsync();
        }
    }
}