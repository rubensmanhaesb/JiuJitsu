
using RMB.Core.ValuesObjects.Logradouro;

namespace CRM.Application.Dtos.PessoaJuridica
{
    public class PessoaDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; } = new();
    }
}
