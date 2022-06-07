using Games_Storage.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Games_Storage.Persistence.Repositories
{
    public class RepositoryWriting<TEntity> : IRepositoryWriting<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public RepositoryWriting(DbContext dbContext)
        {
            Context = dbContext;
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
