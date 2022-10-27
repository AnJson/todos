using Todos.Interfaces;
using Todos.Model;
using Todos.Model.Auth;

namespace Todos.Repositories
{
    public class AuthRepository : MongoDbRepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(IMongoDbContext context)
        : base(context)
        {
        }
    }
}
