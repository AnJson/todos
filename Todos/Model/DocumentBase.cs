using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Todos.Interfaces;

namespace Todos.Models;

public abstract class DocumentBase : IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    // public DateTime CreatedAt => Id.CreationTime;
}
