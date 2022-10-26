using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Todos.Infrastructure;
using System.Text.Json;
using Todos.Models;

namespace Todos.Model
{
    public class Todo : DocumentBase
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; } = null!;

        [BsonElement("done")]
        public bool Done { get; set; } = false;

        [BsonCollection("Todo")]
        public Todo(String title, String description)
        {
            Title = title;
            Description = description;
        }

        public override string ToString() => JsonSerializer.Serialize<Todo>(this);
    }
}
