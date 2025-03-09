using CRM.Domain.Entities;
using RMB.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Interfaces.Repositories
{
    public interface IPessoaJuridicaRepository : 
        IBaseAddRepository<PessoaJuridica>,
        IBaseUpdateRepository<PessoaJuridica>,
        IBaseDeleteRepository<PessoaJuridica>,
        IBaseQueryRepository<PessoaJuridica>
    {
    }
}
