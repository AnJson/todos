using Todos.Contracts.Todo;
using Todos.Model;

namespace Todos.Interfaces
{
    public interface ITodoService
    {
        public Task<List<TodoResponse>> GetAsync();

        public Task<TodoResponse?> GetAsync(string id);

        public Task CreateAsync(CreateTodoRequest newTodoItem);

        public Task UpdateAsync(string id, Todo updatedTodoItem);

        public Task RemoveAsync(string id);
    }

}
