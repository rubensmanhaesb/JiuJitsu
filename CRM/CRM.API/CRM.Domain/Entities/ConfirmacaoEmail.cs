using RMB.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class ConfirmacaoEmail : Entity<Guid>
    {
        public Guid PessoaId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiraEm { get; set; }
        public DateTime? ConfirmadoEm { get; set; }

        // 
        #region Propriedades de Navegacao
        public Pessoa Pessoa { get; set; } = null!;
        #endregion 
    }


}
