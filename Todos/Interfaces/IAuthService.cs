using Todos.Model;
using Todos.Model.Auth;

namespace Todos.Interfaces
{
    public interface IAuthService
    {
        public Task<List<Auth>> GetAsync();

        public Task<Auth?> GetAsync(string id);

        public Task CreateAsync(Auth newUser);

        public Task UpdateAsync(string id, Auth updatedUser);

        public Task RemoveAsync(string id);
    }
}
