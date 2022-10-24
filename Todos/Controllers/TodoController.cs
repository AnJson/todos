using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todos.Model;

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTodos")]
        public IEnumerable<Todo> Get()
        {
            return Enumerable.Empty<Todo>(); // Fix this.
        }
    }
}
