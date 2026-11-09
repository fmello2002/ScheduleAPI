namespace ScheduleAPI.Application.DTOs.Requests
{
    public record CadastrarClienteInput(string Nome, string Telefone, string Email, string CPF)
    {
        public string Nome { get; } = Nome;
        public string Telefone { get; } = Telefone;
        public string Email { get; } = Email;
        public string CPF { get; } = CPF;
    }
}