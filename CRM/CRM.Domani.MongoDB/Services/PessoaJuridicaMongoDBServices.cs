using CRM.Domain.MongoDB.Collection.Logs;
using CRM.Domain.MongoDB.Interfaces.Persistences;
using CRM.Domain.MongoDB.Interfaces.Services;

namespace CRM.Domain.MongoDB.Services
{
    public class PessoaJuridicaMongoDBServices : IPessoaJuridicaMongoDBServices
    {
        private readonly IPessoaJuridicaPersistence _pessoaJuridicaPersistence;

        public PessoaJuridicaMongoDBServices(IPessoaJuridicaPersistence pessoaJuridicaPersistence)
        {
            _pessoaJuridicaPersistence = pessoaJuridicaPersistence;
        }

        public async Task DeleteAsync(Guid id)
            => await _pessoaJuridicaPersistence.DeleteAsync(id);

        public async Task<List<PessoaJuridicaCollection>> GetAllAsync()
            => await _pessoaJuridicaPersistence.GetAllAsync();

        public async Task<PessoaJuridicaCollection> GetByIdAsync(Guid id)
            => await _pessoaJuridicaPersistence.GetByIdAsync(id);

        public async Task InsertAsync(PessoaJuridicaCollection pessoaJuridica)
            => await _pessoaJuridicaPersistence.InsertAsync(pessoaJuridica);

        public async Task UpdateAsync(PessoaJuridicaCollection pessoaJuridica)
            => await _pessoaJuridicaPersistence.UpdateAsync(pessoaJuridica);
    }
}
