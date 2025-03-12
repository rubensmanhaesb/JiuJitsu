using RMB.Abstractions.Repositories;

namespace CRM.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IPessoaJuridicaRepository PessoaJuridicaRepository { get; }
    
    }
}
