using Todos.Model;

namespace Todos.Interfaces
{
    public interface IMongoDbRepository<TDocument> where TDocument : IDocument
    {
        Task<List<TDocument>> GetAsync();
        Task<TDocument?> GetAsync(string id);
        Task<List<TDocument?>> GetAsync(TDocument todo);
        Task CreateAsync(TDocument document);
        Task UpdateAsync(string id, TDocument document);
        Task DeleteAsync(string id);
    }

}
