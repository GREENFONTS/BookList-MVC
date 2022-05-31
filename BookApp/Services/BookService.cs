using BookApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookApp.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IOptions<BookDatabaseSettings> bookDatabaseSettings)
        {
            var mongoClient = new MongoClient(bookDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(bookDatabaseSettings.Value.DatabaseName);

            _books = mongoDatabase.GetCollection<Book>(bookDatabaseSettings.Value.CollectionsName);
        }

        public async Task<List<Book>> GetBooks() => await _books.Find(_ => true).ToListAsync();

        public async Task<Book?> GetBook(string id) => await _books.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateBook(Book newBook)
        {
            await _books.InsertOneAsync(newBook);
        }

        public async Task UpdateBook(string id, Book updatedBook) => await _books.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task DeleteBook(string id) => await _books.DeleteOneAsync(x => x.Id == id);
    }
}
