using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleAPI.Application.DTOs.Requests
{
    public class NovaSolicitacaoInput
    {
        public string Observacao { get; set; } = string.Empty;
        public Guid HorarioId { get; set; }
        public Guid ClienteId { get; set; }
    }
}