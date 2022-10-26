using MongoDB.Driver;

namespace Todos.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<TDocument> Collection<TDocument>()
            where TDocument : IDocument;
    }
}
