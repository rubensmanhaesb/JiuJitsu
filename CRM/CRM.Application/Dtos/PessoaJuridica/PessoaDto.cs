using RMB.Abstractions.Dtos;

namespace CRM.Application.Dtos.PessoaJuridica
{
    public class PessoaDto : Dto<Guid>
    {
        public string Email { get; set; }
    }
}
