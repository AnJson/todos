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
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService) =>
            _todoService = todoService;

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            try
            {
                return await _todoService.GetAsync();
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
            }

        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Todo>> Get(string id)
        {
            var todoItem = await _todoService.GetAsync(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            return todoItem;
        }

        public async Task<ActionResult<List<Todo>>> Get(Todo? todo)
        {
            try
            {
                return await _todoService.GetAsync(todo);

                /*
                 * Example of checking for duplicates in DB.
                 * 
                 Todo todo = _todoService.GetTodoByTitle(todo.Title);
                 if (todo == null) {
                     ModelState.AddModelError("title", "Todo-title already in use.");
                     return BadRequest(ModelState);
                 }
                 */

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Todo newTodoItem)
        {
            await _todoService.CreateAsync(newTodoItem);

            return CreatedAtAction(nameof(Get), new { id = newTodoItem.Id }, newTodoItem);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Todo updatedTodoItem)
        {
            var TodoItem = await _todoService.GetAsync(id);

            if (TodoItem is null)
            {
                return NotFound();
            }

            updatedTodoItem.Id = TodoItem.Id;

            await _todoService.UpdateAsync(id, updatedTodoItem);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var TodoItem = await _todoService.GetAsync(id);

            if (TodoItem is null)
            {
                return NotFound();
            }

            await _todoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
