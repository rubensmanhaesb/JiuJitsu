using RMB.Abstractions.Entities;
using RMB.Core.ValuesObjects.Logradouro;

namespace CRM.Domain.Entities
{
    public class Pessoa : Entity<Guid>
    {
        public string Email { get; set; }

        public bool EmailConfirmado { get; set; }

        #region Propriedades de Navegacao
        public Endereco Endereco { get; set; }
        public ICollection<ConfirmacaoEmail> ConfirmacoesEmail { get; set; } = new List<ConfirmacaoEmail>();
        #endregion

    }
}
