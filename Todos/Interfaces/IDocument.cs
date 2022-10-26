using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todos.Interfaces;

    public interface IDocument
{
    // [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    string? Id { get; set; }

    // [BsonElement("createdAt")]
    //  DateTime CreatedAt { get; }
}
