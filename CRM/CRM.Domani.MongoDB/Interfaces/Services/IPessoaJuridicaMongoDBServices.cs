using CRM.Domain.MongoDB.Collection.Logs;

namespace CRM.Domain.MongoDB.Interfaces.Services
{
    public interface IPessoaJuridicaMongoDBServices
    {
        Task InsertAsync(PessoaJuridicaCollection pessoaJuridica);
        Task UpdateAsync(PessoaJuridicaCollection pessoaJuridica);
        Task DeleteAsync(Guid id);
        Task<List<PessoaJuridicaCollection>> GetAllAsync();
        Task<PessoaJuridicaCollection> GetByIdAsync(Guid id);

    }
}
