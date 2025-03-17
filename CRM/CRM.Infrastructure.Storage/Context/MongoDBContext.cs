using CRM.Domain.MongoDB.Collection.Logs;
using CRM.Domain.MongoDB.Interfaces.Persistences;
using CRM.Infrastructure.Storage.Settings;
using MongoDB.Driver;


namespace CRM.Infrastructure.Storage.Context
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly MongoDBSettings _mongoDBSettings;
        private IMongoDatabase? _mongoDatabase;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;
            Configure();
        }

        public  IMongoCollection<PessoaJuridicaCollection> PessoaJuridicaCollection()
            => _mongoDatabase.GetCollection<PessoaJuridicaCollection>("PessoaJuridica");


        private void Configure()
        {
            var mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings?.Host));

            if (_mongoDBSettings.IsSSL)
                mongoClientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };


            var mongoClient = new MongoClient(mongoClientSettings);
            _mongoDatabase = mongoClient.GetDatabase(_mongoDBSettings.Database);

        }


    }
}
