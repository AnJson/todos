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
        public string Title { get;}

        [BsonElement("description")]
        public string Description { get;} = null!;

        [BsonElement("done")]
        public bool Done { get;} = false;

        public override string ToString() => JsonSerializer.Serialize<Todo>(this);

        public Todo(string title, string description, bool done)
        {
            // TODO: Validate?
            Title = title;
            Description = description;
            Done = done;
        }
    }
}
