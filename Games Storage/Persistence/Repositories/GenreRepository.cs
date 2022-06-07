using Games_Storage.Core.Models;
using Games_Storage.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Games_Storage.Persistence.Repositories
{
    public class GenreRepository : RepositoryReading<Genre>, IGenreRepository
    {
        public GenreRepository(SqlDatabaseContext dbContext) : base(dbContext)
        {
        }

        public Genre? Get(byte id)
        {
            return Context.Set<Genre>().Find(id);
        }
    }
}
