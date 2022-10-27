using Todos.Interfaces;

namespace Todos.Models;

public class TodoDbSettings : ITodoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
