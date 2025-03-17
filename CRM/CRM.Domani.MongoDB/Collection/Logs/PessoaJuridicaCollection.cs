using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CRM.Domain.MongoDB.Collection.Logs
{
    public class PessoaJuridicaCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonElement("RazaoSocial")]
        public string? RazaoSocial { get; set; }
        [BsonElement("NomeFantasia")]
        public string? NomeFantasia { get; set; }
        [BsonElement("Cnpj")]
        public string? Cnpj { get; set; }
        [BsonElement("Email")]
        public string? Email { get; set; }
    }
}
