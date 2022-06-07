using System.Linq.Expressions;

namespace Games_Storage.Core.Repositories
{
    public interface IRepository<TEntity> : IRepositoryReading<TEntity>, IRepositoryWriting<TEntity> where TEntity : class
    {
    }
}
