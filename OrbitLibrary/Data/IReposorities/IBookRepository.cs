using OrbitLibrary.Data.Entities;

namespace OrbitLibrary.Data.IReposorities
{
    public interface IBookRepository : IRepository<Book>
    {
        public Task AddAuthor(int bookId, int authorId);
        public Task RemoveAuthor(int bookId, int authorId);
    }
}