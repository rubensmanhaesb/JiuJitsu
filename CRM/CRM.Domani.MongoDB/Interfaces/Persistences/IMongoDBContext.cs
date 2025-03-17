using CRM.Domain.MongoDB.Collection.Logs;
using MongoDB.Driver;

namespace CRM.Domain.MongoDB.Interfaces.Persistences
{
    public interface IMongoDBContext
    {
        public IMongoCollection<PessoaJuridicaCollection> PessoaJuridicaCollection();

    }
}
