using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Todos.Infrastructure;
using System.Text.Json;
using Todos.Models;

namespace Todos.Model
{
    [BsonCollection("Todo")]
    public class Todo : DocumentBase
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; } = null!;

        [BsonElement("done")]
        public bool Done { get; set; } = false;

        [BsonElement("updated")]
        public DateTime UpdatedAt { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Todo>(this);
    }
}
