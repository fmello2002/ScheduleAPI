using ScheduleAPI.Domain.Exceptions;

namespace ScheduleAPI.Domain.Entities
{
    public class Agendamento
    {
        public Guid Id { get; }
        public Guid HorarioId { get; set; }
        public Horario Horario { get; }
        public string Observacao { get; } = string.Empty;

        public Guid ClienteId { get; }

        public Cliente Cliente { get; } = null!;

        private Agendamento()
        { }

        public Agendamento(Guid horarioId, string observacao, Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
                throw new DomainException($"Usuário é obrigatório.");

            Id = Guid.NewGuid();
            HorarioId = horarioId;
            Observacao = observacao ?? string.Empty;
            ClienteId = usuarioId;
        }
    }
}