using CRM.Domain.Entities;
using RMB.Abstractions.Domains;

namespace CRM.Domain.Interfaces.Services
{
    public interface IPessoaJuridicaDomainService : 
            IBaseAddDomain<PessoaJuridica>,
            IBaseUpdateDomain<PessoaJuridica>,
            IBaseDeleteDomain<PessoaJuridica>,
            IBaseQueryDomain<PessoaJuridica>
    {
    }
}
