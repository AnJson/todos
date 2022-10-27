using Todos.Interfaces;
using Todos.Model;
using Todos.Models;
using Todos.Repositories;

namespace Todos.Repositories;

public class TodoRepository : MongoDbRepositoryBase<Todo>, ITodoRepository
{
    public TodoRepository(IMongoDbContext context)
        : base(context)
    {
    }
}
