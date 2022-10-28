using Todos.Interfaces;

namespace Todos.Models;

public class MongoDbSettings : IMongoDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
