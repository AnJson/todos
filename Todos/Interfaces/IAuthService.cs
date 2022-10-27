using Todos.Model;
using Todos.Model.Auth;

namespace Todos.Interfaces
{
    public interface IAuthService
    {
        public Task<List<User>> GetAsync();

        public Task<User?> GetAsync(string id);

        public Task CreateAsync(User newUser);

        public Task UpdateAsync(string id, User updatedUser);

        public Task RemoveAsync(string id);
    }
}
