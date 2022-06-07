using Games_Storage.Core.Repositories;

namespace Games_Storage.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Games { get;  }
        IStudioRepository Studios { get; }
        IGenreRepository Genres { get;  }
        int Complete();
    }
}
