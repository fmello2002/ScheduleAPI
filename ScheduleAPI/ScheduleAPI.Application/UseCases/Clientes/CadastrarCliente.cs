using ScheduleAPI.Application.DTOs.Requests;
using ScheduleAPI.Application.Repositories;
using ScheduleAPI.Domain.Entities;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Application.UseCases.Clientes
{
    public class CadastrarCliente(IClienteRepository _repository)
    {
        public async Task ExecuteAsync(CadastrarClienteInput usuarioInput)
        {
            var email = new Email(usuarioInput.Email);
            var cpf = new CPF(usuarioInput.CPF);

            Cliente usuario = new(usuarioInput.Nome, usuarioInput.Telefone, email, cpf);

            await _repository.CadastrarCliente(usuario);
        }
    }
}