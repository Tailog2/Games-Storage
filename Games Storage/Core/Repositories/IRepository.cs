using System.Linq.Expressions;

namespace Games_Storage.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? Get(int id);
        IEnumerable<TEntity>? GetAll();
        IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
