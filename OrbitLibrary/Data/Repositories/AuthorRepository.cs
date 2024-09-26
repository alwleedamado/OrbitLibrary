using Microsoft.EntityFrameworkCore;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Data.IReposorities;

namespace OrbitLibrary.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext db) : base(db)
        {
        }
    }
}
