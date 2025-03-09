using RMB.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Dtos.PessoaJuridica
{
    public class PessoaDto : Dto<Guid>
    {
        public string Email { get; set; }
    }
}
