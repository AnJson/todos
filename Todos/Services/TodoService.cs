using AutoMapper;
using Todos.Interfaces;
using Todos.Model;
using Todos.Model.DTO.Todo;

namespace Todos.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoResponse>> GetAsync(IMapper mapper)
        {
            List<Todo> todos = await _repository.GetAsync();
            return mapper.Map<List<TodoResponse>>(todos);
        }

        public async Task<Todo?> GetAsync(string id) =>
            await _repository.GetAsync(id);

        public async Task<List<Todo?>> GetAsync(Todo todo) =>
            await _repository.GetAsync(todo);

        public async Task CreateAsync(Todo newTodoItem) =>
            await _repository.CreateAsync(newTodoItem);

        public async Task UpdateAsync(string id, Todo updatedTodoItem) =>
            await _repository.UpdateAsync(id, updatedTodoItem);

        public async Task RemoveAsync(string id) =>
            await _repository.DeleteAsync(id);
    }
}
