using ScheduleAPI.Domain.Exceptions;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Domain.Entities
{
    public class Solicitacao
    {
        public Guid Id { get; set; }

        public Guid HorarioId { get; set; }
        public Horario Horario { get; set; }
        public string Observacao { get; } = string.Empty;

        public Guid ClienteId { get; set; }

        public Cliente Cliente { get; set; } = null!;

        public StatusSolicitacao Status { get; set; }

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
            Status = StatusSolicitacao.Pendente;
        }

        public Agendamento Aprovar()
        {
            if (Status != StatusSolicitacao.Pendente)
                throw new DomainException("Apenas solicitações pendentes podem ser aprovadas.");

            Status = StatusSolicitacao.Aprovada;
            Horario.StatusHorario = StatusHorario.Indisponivel;
            return new Agendamento(HorarioId, Observacao, ClienteId);
        }
    }
}