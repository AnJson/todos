using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<Todo>> Get() =>
            await _todoItemsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Todo>> Get(string id)
        {
            var todoItem = await _todoItemsService.GetAsync(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Todo newTodoItem)
        {
            await _todoItemsService.CreateAsync(newTodoItem);

            return CreatedAtAction(nameof(Get), new { id = newTodoItem.Id }, newTodoItem);
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
