using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Infrastructure.Persistence.Configurations
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.HorarioId)
                .IsRequired();

            builder.Property(a => a.Observacao)
                .HasMaxLength(200);

            builder.Property(a => a.ClienteId)
                .IsRequired();
        }
    }
}