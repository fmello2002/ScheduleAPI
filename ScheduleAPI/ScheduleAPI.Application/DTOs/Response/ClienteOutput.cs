namespace ScheduleAPI.Application.DTOs.Response
{
    public record ClienteOutput(
    Guid id,
    string Nome,
    string Telefone,
    string Email,
    string CPF
);
}