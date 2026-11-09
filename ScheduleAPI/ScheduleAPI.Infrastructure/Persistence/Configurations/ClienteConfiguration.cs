using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleAPI.Domain.Entities;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Infrastructure.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Telefone).IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.Email).HasConversion(email => email.Value,
                                                         value => new Email(value)).IsRequired().HasMaxLength(150);

            builder.Property(u => u.CPF).HasConversion(cpf => cpf.Value,
                                                       value => new CPF(value)).IsRequired().HasMaxLength(11);
        }
    }
}