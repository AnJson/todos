using MongoDB.Bson.Serialization.Attributes;
using Todos.Models;

namespace Todos.Model.DTO.Todo

{
    public class TodoResponse
    {
        public string Id { get; set; }
        public string Title { get; }
        public string Description { get; }
        public bool Done { get; }

        public TodoResponse(string title, string description, bool done, string id)
        {
            Title = title;
            Description = description;
            Done = done;
            Id = id;
        }
    }
}