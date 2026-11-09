using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Application.UseCases
{
    public class CadastrarAtendente(IAtendenteRepository repository)
    {
        public async Task Execute(CadastrarAtendenteInput input)
        {
            var email = new Email(input.Email);
            var cpf = new CPF(input.CPF);

            var atendente = new Atendente(input.Nome, input.Telefone, email, cpf);
            await repository.CadastrarAtendente(atendente);
        }
    }
}