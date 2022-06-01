using Games_Storage.Core.Models;
using Games_Storage.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Games_Storage.Persistence.Repositories
{
    public class StudioRepository : Repository<Studio>, IStudioRepository
    {
        public StudioRepository(SqlDatabaseContext dbContext)
            :base(dbContext)
        {
        }

        public SqlDatabaseContext SqlDatabaseContext
        {
            get { return Context as SqlDatabaseContext;  }
        }
    }
}
