using Microsoft.EntityFrameworkCore;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Data.IReposorities;
#pragma warning disable CS8603 // Possible null reference return.

namespace OrbitLibrary.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext dbContext) : base(dbContext) { }


        public override async Task<Book> GetOne(int id)
        {
            return await db.Set<Book>()
                .Include(x => x.Authors)
                .ThenInclude(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAuthor(int bookId, int authorId)
        {
            var book = await db.Set<Book>()
                .Include(x => x.Authors)
                .FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null) throw new InvalidOperationException("Book Not found");

            book.Authors.Add(new BookAuthors() { AuthorId = authorId });
        }

        public async Task RemoveAuthor(int bookId, int authorId)
        {
            var book = await db.Set<Book>()
                .Include(x => x.Authors)
                .FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null) throw new InvalidOperationException("Book Not found");
            var idx = book.Authors.FindIndex(x => x.AuthorId == authorId);
            book.Authors.RemoveAt(idx);
        }
    }
}