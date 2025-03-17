
namespace CRM.Infrastructure.Storage.Settings
{
    public class MongoDBSettings
    {
        public string? Host { get; set; }
        public string? Database { get; set; }
        public bool IsSSL { get; set; }
    }
}
