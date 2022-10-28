using Todos.Interfaces;
using Todos.Model;
using Todos.Model.Auth;

namespace Todos.Repositories
{
    public class AuthRepository : MongoDbRepositoryBase<Auth>, IAuthRepository
    {
        public AuthRepository(IMongoDbContext context)
        : base(context)
        {
        }
    }
}
