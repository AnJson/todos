using System.Text.Json;
using Todos.Model;

namespace Todos.Services
{
    public class JsonFileTodoService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileTodoService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName => Path.Combine(WebHostEnvironment.ContentRootPath, "data", "todos.json");

        public IEnumerable<Todo> GetTodos()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Todo[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
