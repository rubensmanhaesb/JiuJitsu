using RMB.Abstractions.Entities;
using RMB.Core.ValuesObjects.Logradouro;

namespace CRM.Domain.Entities
{
    public class Pessoa : Entity<Guid>
    {

        public string Email { get; set; }
        public Endereco Endereco { get; set; }

    }
}
