using ScheduleAPI.Domain.Exceptions;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; }
        public string Nome { get; } = string.Empty;
        public string Telefone { get; } = string.Empty;
        public Email Email { get; } = null!;
        public CPF CPF { get; } = null!;

        private Cliente()
        { }

        public Cliente(string nome, string telefone, Email email, CPF cpf)
        {
            Id = Guid.NewGuid();
            Nome = string.IsNullOrWhiteSpace(nome) ? throw new DomainException("Nome é obrigatório.") : nome.Trim();
            Telefone = string.IsNullOrWhiteSpace(telefone) ? throw new DomainException("Telefone é obrigatório.") : telefone;
            Email = email ?? throw new DomainException("Email é obrigatório.");
            CPF = cpf ?? throw new DomainException("CPF é obrigatório.");
        }
    }
}