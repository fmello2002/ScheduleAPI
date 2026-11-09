using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Infrastructure.Persistence.Configurations
{
    public class HorarioConfiguration : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.ToTable("Horarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Dia)
                .IsRequired();

            builder.Property(u => u.Hora)
                .IsRequired();

            builder.Property(u => u.StatusHorario)
                .IsRequired();
        }
    }
}