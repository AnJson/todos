using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todos.Contracts.Todo;
using Todos.Interfaces;
using Todos.Model;
using Todos.Services;

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoItemsService;

        public TodoController(ITodoService todoItemsService) =>
            _todoItemsService = todoItemsService;

        [HttpGet]
        public async Task<List<TodoResponse>> Get() =>
            await _todoItemsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TodoResponse>> Get(string id)
        {
            var todo = await _todoItemsService.GetAsync(id);

            if (todo is null)
            {
                return NotFound();
            }

            TodoResponse response = new (
                Id: todo.Id,
                Title: todo.Title,
                Description: todo.Description,
                Done: todo.Done
                );

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTodoRequest request)
        {
            Todo todo = new (
                title: request.Title,
                description: request.Description,
                done: request.Done
                );

            await _todoItemsService.CreateAsync(todo);

            TodoResponse response = new (
                Id: todo.Id,
                Title: todo.Title,
                Description: todo.Description,
                Done: todo.Done
                );

            return CreatedAtAction(nameof(Get), new { id = todo.Id }, value: response);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Todo updatedTodoItem)
        {
            var TodoItem = await _todoItemsService.GetAsync(id);

            if (TodoItem is null)
            {
                return NotFound();
            }

            updatedTodoItem.Id = TodoItem.Id;

            await _todoItemsService.UpdateAsync(id, updatedTodoItem);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var TodoItem = await _todoItemsService.GetAsync(id);

            if (TodoItem is null)
            {
                return NotFound();
            }

            await _todoItemsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
