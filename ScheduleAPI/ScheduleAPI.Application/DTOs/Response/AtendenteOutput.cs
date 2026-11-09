namespace ScheduleAPI.Application.DTOs.Response
{
    public record AtendenteOutput(
    Guid id,
    string Nome,
    string Telefone,
    string Email,
    string CPF
);
}