using Todos.Model;
using Todos.Model.DTO.Todo;

namespace Todos.Interfaces
{
    public interface ITodoService
    {
        public Task<List<TodoResponse>> GetAsync();

        public Task<TodoResponse?> GetAsync(string id);

        public Task<List<TodoResponse?>> GetAsync(Todo todo);

        public Task CreateAsync(TodoCreate newTodoItem);

        public Task UpdateAsync(string id, Todo updatedTodoItem);

        public Task RemoveAsync(string id);
    }

}
