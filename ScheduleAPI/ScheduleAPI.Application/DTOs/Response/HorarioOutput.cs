namespace ScheduleAPI.Application.DTOs.Response
{
    public record HorarioOutput(Guid Id, DateTime Horario, string? Status)
    {
    }
}