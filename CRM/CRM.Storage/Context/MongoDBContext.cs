using CRM.Storage.Collections.Logs;
using CRM.Storage.Settings;
using MongoDB.Driver;


namespace CRM.Storage.Context
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings _mongoDBSettings;
        private IMongoDatabase? _mongoDatabase;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;
            Configure();
        }

        public IMongoCollection<PessoaJuridicaCollection> PessoaJuridica
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
