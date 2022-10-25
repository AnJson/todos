using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todos.Model;
using Todos.Services;

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public JsonFileTodoService TodoService { get; }

        public TodoController(JsonFileTodoService todoService)
        {
            TodoService = todoService;
        }

        [Authorize]
        [HttpGet(Name = "GetTodos")]
        public IEnumerable<Todo> Get()
        {
            return TodoService.GetTodos();
        }
    }
}
