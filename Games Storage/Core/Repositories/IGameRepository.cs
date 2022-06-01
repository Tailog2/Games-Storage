using Games_Storage.Core.Models;
using System.Linq.Expressions;

namespace Games_Storage.Core.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        IEnumerable<Game> GetGamesByGenre(Genre genre);
        Genre GetGenre(byte genreId);
    }
}
