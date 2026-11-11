using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.Repositories;

namespace ScheduleAPI.Application.UseCases.Agendamentos
{
    public class NovoAgendamento(IAgendamentoRepository agendamentoRepository, IClienteRepository usuarioRepository)
    {
        public async Task ExecuteAsync(NovoAgendamentoInput agendamentoInput)
        {
            var usuario = await usuarioRepository.BuscarCliente(agendamentoInput.UsuarioId);
            if (usuario is null)
                throw new Exception("Usuário não encontrado");
            var agendamento = new Domain.Entities.Agendamento(agendamentoInput.HorarioId, agendamentoInput.Observacao, usuario.Id);
            await agendamentoRepository.NovoAgendamento(agendamento);
        }
    }
}