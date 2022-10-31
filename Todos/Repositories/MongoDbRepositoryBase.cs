using MongoDB.Bson;
using MongoDB.Driver;
using Todos.Interfaces;

namespace Todos.Repositories
{
    public abstract class MongoDbRepositoryBase<TDocument>
    : IMongoDbRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoDbContext _context;
        private readonly IMongoCollection<TDocument> _collection;

        public MongoDbRepositoryBase(IMongoDbContext context)
        {
            _context = context;
            _collection = _context.Collection<TDocument>();
        }

        public virtual async Task<List<TDocument>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public virtual async Task<TDocument?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public virtual async Task<List<TDocument?>> GetAsync(TDocument doc)
        {
            FilterDefinition<BsonDocument> filter = new BsonDocument(doc.ToBsonDocument());
            return await _collection.Find("${doc.toString()}").ToListAsync(); // TODO: FIlter Definition
        }

        public virtual async Task CreateAsync(TDocument document) =>
            await _collection.InsertOneAsync(document);

        public virtual async Task UpdateAsync(string id, TDocument document) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, document);
        public virtual async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}


