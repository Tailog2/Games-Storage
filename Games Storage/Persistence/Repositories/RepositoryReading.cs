using Games_Storage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Games_Storage.Persistence.Repositories
{
    public class RepositoryReading<TEntity> : IRepositoryReading<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public RepositoryReading(DbContext dbContext)
        {
            Context = dbContext;
        }

        public virtual TEntity? Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity>? GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }
    }
}
