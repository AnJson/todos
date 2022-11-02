using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todos.Interfaces;
using Todos.Model;
using Todos.Model.DTO.Todo;
using Todos.Services;

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoController(ITodoService todoService, IMapper mapper) 
        { 
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoResponse>>> Get()
        {
            try
            {
                List<Todo> todos = await _todoService.GetAsync();
                return _mapper.Map<List<TodoResponse>>(todos);
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
            }

        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TodoResponse?>> Get(string id)
        {
            try
            {
                var todoItem = await _todoService.GetAsync(id);

                if (todoItem is null)
                {
                    return NotFound();
                }

                return _mapper.Map<TodoResponse>(todoItem);
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoCreate newTodoItem)
        {
            try
            {
                /*
                 * Example of checking for duplicates in DB.
                 * 
                 Todo todo = _todoService.GetTodoByTitle(todo.Title);
                 if (todo == null) {
                     ModelState.AddModelError("title", "Todo-title already in use.");
                     return BadRequest(ModelState);
                 }
                 */
                Todo createdTodo = _mapper.Map<Todo>(newTodoItem);
                await _todoService.CreateAsync(createdTodo);
                return CreatedAtAction(nameof(Get), new { id = createdTodo.Id }, createdTodo);
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database.");
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Todo updatedTodoItem)
        {
            try
            {
                var TodoItem = await _todoService.GetAsync(id);

                if (TodoItem is null)
                {
                    return NotFound();
                }

                updatedTodoItem.Id = TodoItem.Id;

                await _todoService.UpdateAsync(id, updatedTodoItem);

                return NoContent();
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database.");
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var TodoItem = await _todoService.GetAsync(id);

                if (TodoItem is null)
                {
                    return NotFound();
                }

                await _todoService.RemoveAsync(id);

                return NoContent();
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database.");
            }
        }
    }
}
