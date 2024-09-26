using Microsoft.EntityFrameworkCore;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Data.IReposorities;

namespace OrbitLibrary.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContext db;

        public Repository(DbContext db)
        {
            this.db = db;
        }

        public async Task AddMany(IEnumerable<T> entities)
        {
            await db.AddRangeAsync(entities);
        }

        public async Task AddOne(T entity)
        {
            await db.Set<T>().AddAsync(entity);
        }

        public async Task DeleteMany(IEnumerable<T> entities)
        {
            await db.Set<T>().AddRangeAsync(entities);
        }

        public async Task DeleteOne(int id)
        {

            var entity = await db.Set<T>().FirstOrDefaultAsync();
            if (entity == null)
                throw new InvalidOperationException("Entity not found");
            await DeleteOne(entity);
        }

        public async Task DeleteOne(T entity)
        {

            await Task.Run(() => db.Set<T>().Remove(entity));
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync()
                .ConfigureAwait(true);
        }

        public virtual async Task<T> GetOne(int id)
        {
            var item = await db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;
            return item;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }

        public async Task<T> UpdateOne(T entity)
        {
            var existing = await db.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existing == null)
                throw new InvalidOperationException($"Entity not found by id {entity.Id}");
            db.Set<T>().Update(entity);
            return entity;
        }
    }
}
