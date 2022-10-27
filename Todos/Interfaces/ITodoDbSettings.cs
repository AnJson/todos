namespace Todos.Interfaces
{
    public interface ITodoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
