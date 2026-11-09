using ScheduleAPI.Domain.Entities;
using ScheduleAPI.Domain.ValueObjects;

namespace ScheduleAPI.Test
{
    public class UsuarioCtor
    {
        [Fact]
        public void Deve_Lancar_ArgumentException_Quando_Valor_Invalido()
        {
            // arrange
            // act && assert
            Assert.Throws<ArgumentException>(() => new Cliente
            (
                "Felipe",
                "123456789",
                new Email("felipeteste.com"), // E-mail inválido
                new CPF("62041337052") // CPF válido
            ));
        }
    }
}