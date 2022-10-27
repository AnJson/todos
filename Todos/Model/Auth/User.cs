using Todos.Models;

namespace Todos.Model.Auth
{
    public class User : DocumentBase
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
