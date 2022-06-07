using Games_Storage.Core.Models;

namespace Games_Storage.Core.Repositories
{
    public interface IGenreRepository : IRepositoryReading<Genre>
    {
        Genre Get(byte id);
    }
}
