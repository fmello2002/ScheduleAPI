namespace ScheduleAPI.Application.DTOs.Response
{
    public record SolicitacaoOutPut(Guid id, DateTime Horario, string Cliente, string Status, string Observacao)
    {
    }
}