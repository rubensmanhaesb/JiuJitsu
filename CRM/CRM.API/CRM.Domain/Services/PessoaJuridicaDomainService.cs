using CRM.Domain.Entities;
using RMB.Abstractions.Domains;
using RMB.Core.Domains;
using RMB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Services
{
    public class PessoaJuridicaDomainService : BaseDomain<PessoaJuridica>,
        IBaseAddDomain<PessoaJuridica>,
        IBaseUpdateDomain<PessoaJuridica>,
        IBaseDeleteDomain<PessoaJuridica>,
        IBaseQueryDomain<PessoaJuridica>
    {
        public PessoaJuridicaDomainService(BaseRepository<PessoaJuridica> repository) : base(repository)
        {
        }
    }
}
