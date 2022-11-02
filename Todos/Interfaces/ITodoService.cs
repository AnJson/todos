using AutoMapper;
using Todos.Model;
using Todos.Model.DTO.Todo;

namespace Todos.Interfaces
{
    public interface ITodoService
    {
        public Task<List<Todo>> GetAsync();

        public Task<Todo?> GetAsync(string id);

        public Task CreateAsync(Todo newTodoItem);

        public Task UpdateAsync(string id, Todo updatedTodoItem);

        public Task RemoveAsync(string id);
    }

}
