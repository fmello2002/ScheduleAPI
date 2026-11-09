namespace ScheduleAPI.Application.DTOs.Response
{
    public record AgendamentoOutput(DateTime Horario, string Observacao, string Usuario)
    {
    }
}