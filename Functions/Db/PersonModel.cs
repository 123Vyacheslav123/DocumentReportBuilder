using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentReportBuilder.Functions
{
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string TypeOfAccount { get; set; }
    }
}
