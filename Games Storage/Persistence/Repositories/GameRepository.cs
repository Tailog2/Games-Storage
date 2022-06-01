using Games_Storage.Core.Models;
using Games_Storage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

#nullable disable
namespace Games_Storage.Persistence.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(SqlDatabaseContext dbContext)
            :base(dbContext)
        {
        }

        public IEnumerable<Game> GetGamesByGenre(Genre genre)
        {
            return SqlDatabaseContext.Set<Genre>()
                .Include(g => g.GamesGenres)
                .ThenInclude(g => g.Game)
                .ToList()
                .SingleOrDefault(g => g.Id == genre.Id)
                .GamesGenres
                .Select(gg => gg.Game);          
        }

        public Genre GetGenre(byte genreId)
        {
            return SqlDatabaseContext.Set<Genre>().Find(genreId);
        }

        public override void Update(Game game)
        {
            UpdateGamesGenres(game);
            SqlDatabaseContext.Set<Game>().Update(game);
        }

        public SqlDatabaseContext SqlDatabaseContext
        {
            get { return Context as SqlDatabaseContext; }
        }

        private void UpdateGamesGenres(Game game) 
        {
            var previousGamesGenres = SqlDatabaseContext.Set<GamesGenres>()
               .Where(gg => gg.GamesId == game.Id)
               .ToList();

            SqlDatabaseContext.Set<GamesGenres>().RemoveRange(previousGamesGenres);
            SqlDatabaseContext.Set<GamesGenres>().AddRange(game.GamesGenres);
        }
    }
}
