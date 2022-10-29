using Todos.Interfaces;
using Todos.Model;

namespace Todos.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Todo>> GetAsync() =>
            await _repository.GetAsync();

        public async Task<Todo?> GetAsync(string id) =>
            await _repository.GetAsync(id);

        public async Task<List<Todo>> GetAsync(Todo? todo) =>
            await _repository.GetAsync(todo);

        public async Task CreateAsync(Todo newTodoItem) =>
            await _repository.CreateAsync(newTodoItem);

        public async Task UpdateAsync(string id, Todo updatedTodoItem) =>
            await _repository.UpdateAsync(id, updatedTodoItem);

        public async Task RemoveAsync(string id) =>
            await _repository.DeleteAsync(id);
    }
}
