using Microsoft.EntityFrameworkCore;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Data.IReposorities;

namespace OrbitLibrary.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext dbContext) : base(dbContext) { }

        public override async Task<Book> GetOne(int id)
        {
            return await base.db.Set<Book>().Include(x => x.Authors).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
