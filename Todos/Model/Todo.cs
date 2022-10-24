using System.Text.Json;

namespace Todos.Model
{
    public class Todo
    {
        public string title { get; set; }
        public string description { get; set; }

        public Todo(String title, String description)
        {
            this.title = title;
            this.description = description;
        }

        public override string ToString() => JsonSerializer.Serialize<Todo>(this);
    }
}
