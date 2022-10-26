using MongoDB.Driver;
using Todos.Interfaces;
using Todos.Infrastructure;
using Todos.Interfaces;

namespace Todos.Models;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoDbSettings settings)
    {
        _database = new MongoClient(settings.ConnectionString)
            .GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<TDocument> Collection<TDocument>()
        where TDocument : IDocument =>
        _database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));

    private protected string? GetCollectionName(Type documentType) =>
        ((BsonCollectionAttribute?)Attribute.GetCustomAttribute(
            documentType, typeof(BsonCollectionAttribute)))?.CollectionName;
    // ((BsonCollectionAttribute)documentType
    //     .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
    //     .First()).CollectionName;
}
