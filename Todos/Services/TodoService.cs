using Todos.Contracts.Todo;
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

        public async Task<List<TodoResponse>> GetAsync() =>
            await _repository.GetAsync();

        public async Task<TodoResponse?> GetAsync(string id) =>
            await _repository.GetAsync(id);

        public async Task CreateAsync(CreateTodoRequest request) =>
            await _repository.CreateAsync(request);

        public async Task UpdateAsync(string id, Todo updatedTodoItem) =>
            await _repository.UpdateAsync(id, updatedTodoItem);

        public async Task RemoveAsync(string id) =>
            await _repository.DeleteAsync(id);
    }
}
