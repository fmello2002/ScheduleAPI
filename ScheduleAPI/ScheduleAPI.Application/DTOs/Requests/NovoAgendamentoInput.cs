namespace ScheduleAPI.Application.DTOs.Requests
{
    public record NovoAgendamentoInput(Guid HorarioId, string Observacao, Guid UsuarioId);
}