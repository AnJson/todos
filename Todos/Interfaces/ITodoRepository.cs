using Todos.Model;

namespace Todos.Interfaces
{
    public interface ITodoRepository : IMongoDbRepository<Todo>
    {
    }
}
