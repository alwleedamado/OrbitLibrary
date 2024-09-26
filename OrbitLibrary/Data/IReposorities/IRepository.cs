using OrbitLibrary.Data.Entities;

namespace OrbitLibrary.Data.IReposorities
{
    public interface IRepository<T> where T : Entity
    {
        public Task AddOne(T entity);
        public Task AddMany(IEnumerable<T> entities);
        public Task<T> GetOne(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task DeleteOne(int id);
        public Task DeleteOne(T entity);
        public Task<T> UpdateOne(T entity);
        public Task DeleteMany(IEnumerable<T> entities);
        public Task<int> SaveChangesAsync();
    }
}
