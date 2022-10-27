using Todos.Interfaces;

namespace Todos.Model.Auth
{
    public class AuthDbSettings : IAuthDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
