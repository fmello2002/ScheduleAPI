using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleAPI.Domain.Entities;

namespace ScheduleAPI.Infrastructure.Persistence.Configurations
{
    public class SolicitacaoConfiguration : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.ToTable("Solicitacoes");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.HorarioId)
                .IsRequired();

            builder.Property(a => a.Observacao)
                .HasMaxLength(200);

            builder.Property(a => a.ClienteId)
                .IsRequired();

            builder.Property(a => a.Status)
              .IsRequired();
        }
    }
}