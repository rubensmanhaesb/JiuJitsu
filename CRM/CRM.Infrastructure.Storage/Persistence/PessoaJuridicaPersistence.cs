using CRM.Domain.MongoDB.Collection.Logs;
using CRM.Domain.MongoDB.Interfaces.Persistences;
using MongoDB.Driver;

namespace CRM.Infrastructure.Storage.Persistence
{
    public class PessoaJuridicaPersistence : IPessoaJuridicaPersistence
    {
        private readonly IMongoDBContext _mongoDBContext;

        public PessoaJuridicaPersistence(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task InsertAsync(PessoaJuridicaCollection pessoaJuridica)
        {
            await _mongoDBContext.PessoaJuridicaCollection().InsertOneAsync(pessoaJuridica);
        }
        public async Task UpdateAsync(PessoaJuridicaCollection pessoaJuridica)
        {
            var filter = Builders<PessoaJuridicaCollection>.Filter.Eq(x => x.Id, pessoaJuridica.Id);
            await _mongoDBContext.PessoaJuridicaCollection().ReplaceOneAsync(filter, pessoaJuridica);
        }
        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<PessoaJuridicaCollection>.Filter.Eq(x => x.Id, id);
            await _mongoDBContext.PessoaJuridicaCollection().DeleteOneAsync(filter);
        }
        public async Task<List<PessoaJuridicaCollection>> GetAllAsync()
        {
            var filter = Builders<PessoaJuridicaCollection>.Filter.Where(t => true);
            var result = await _mongoDBContext.PessoaJuridicaCollection().FindAsync(filter);
            return result.ToList();
        }
        public async Task<PessoaJuridicaCollection> GetByIdAsync(Guid id)
        {
            var filter = Builders<PessoaJuridicaCollection>.Filter.Eq(x => x.Id, id);
            var result = await _mongoDBContext.PessoaJuridicaCollection().FindAsync(filter);
            return result.FirstOrDefault();
        }
    }
}
