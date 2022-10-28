
using Todos.Model.Auth;

namespace Todos.Interfaces
{
    public interface IAuthRepository : IMongoDbRepository<Auth>
    {
    }
}
