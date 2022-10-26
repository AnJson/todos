using Todos.Model;

namespace Todos.Interfaces
{
    public interface ITodoItemsService
    {
        public Task<List<Todo>> GetAsync();

        public Task<Todo?> GetAsync(string id);

        public Task CreateAsync(Todo newTodoItem);

        public Task UpdateAsync(string id, Todo updatedTodoItem);

        public Task RemoveAsync(string id);
    }

}
