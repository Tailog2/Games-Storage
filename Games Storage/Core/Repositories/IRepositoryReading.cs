using System.Linq.Expressions;

namespace Games_Storage.Core.Repositories
{
    public interface IRepositoryReading<TEntity> where TEntity : class
    {
        TEntity? Get(int id);
        IEnumerable<TEntity>? GetAll();
        IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
