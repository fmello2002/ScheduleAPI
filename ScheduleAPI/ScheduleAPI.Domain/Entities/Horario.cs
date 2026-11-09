using ScheduleAPI.Domain.Exceptions;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Domain.Entities
{
    public class Horario
    {
        public Guid Id { get; set; }
        public DateOnly Dia { get; set; }
        public TimeOnly Hora { get; set; }
        public StatusHorario StatusHorario { get; set; }

        private Horario()
        { }

        public Horario(DateTime horario)
        {
            if (horario <= DateTime.Now)
                throw new DomainException($"O horário do agendamento deve ser no futuro.");

            Id = Guid.NewGuid();
            Dia = DateOnly.FromDateTime(horario);
            Hora = TimeOnly.FromDateTime(horario);
            StatusHorario = StatusHorario.Disponivel;
        }
    }
}