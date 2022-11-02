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

        public TodoController(ITodoService todoService) =>
            _todoService = todoService;

        [HttpGet]
        public async Task<ActionResult<List<TodoResponse>>> Get()
        {
            try
            {
                List<TodoResponse> todos = await _todoService.GetAsync();
                return todos;
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
            }

        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TodoResponse?>> Get([FromBody]string id, IMapper mapper)
        {
            try
            {
                // TODO: REFACTOR TO MAP IN SERVICE!!!
                var todoItem = await _todoService.GetAsync(id);

                if (todoItem is null)
                {
                    return NotFound();
                }

                return mapper.Map<TodoResponse?>(todoItem);
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
            }
        }

        //[HttpGet]
        //public async Task<ActionResult<List<TodoResponse?>>> Get(Todo todo, IMapper mapper)
        //{
        //    try
        //    {
        //        // TODO: FIlter here???
        //        List<Todo?> todos = await _todoService.GetAsync(todo);
        //        return mapper.Map<List<TodoResponse?>>(todos);
        //
        //
        //        /*
        //         * Example of checking for duplicates in DB.
        //         * 
        //         Todo todo = _todoService.GetTodoByTitle(todo.Title);
        //         if (todo == null) {
        //             ModelState.AddModelError("title", "Todo-title already in use.");
        //             return BadRequest(ModelState);
        //         }
        //         */
        //
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database.");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TodoCreate newTodoItem, IMapper mapper)
        {
            try
            {
                Todo todo = mapper.Map<Todo>(newTodoItem);
                await _todoService.CreateAsync(todo);
                return CreatedAtAction(nameof(Get), new { id = todo.Id }, mapper.Map<TodoResponse>(todo));
            } catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database.");
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update([FromBody]string id, Todo updatedTodoItem)
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
        public async Task<IActionResult> Delete([FromBody]string id)
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
