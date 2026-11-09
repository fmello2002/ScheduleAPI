using ScheduleAPI.Domain.Exceptions;

namespace ScheduleAPI.Domain.Entities
{
    public class Solicitacao
    {
        public Guid Id { get; }

        public Guid HorarioId { get; set; }
        public Horario Horario { get; }
        public string Observacao { get; } = string.Empty;

        public Guid ClienteId { get; }

        public Cliente Cliente { get; } = null!;

        private Solicitacao()
        { }

        public Solicitacao(Guid horarioId, string observacao, Guid clienteId)
        {
            if (clienteId == Guid.Empty)
                throw new DomainException($"Cliente é obrigatório.");

            Id = Guid.NewGuid();
            HorarioId = horarioId;
            Observacao = observacao ?? string.Empty;
            ClienteId = clienteId;
        }
    }
}