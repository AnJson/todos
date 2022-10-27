namespace Todos.Interfaces
{
    public interface IAuthDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
