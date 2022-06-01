using Games_Storage.Core;
using Games_Storage.Core.Repositories;
using Games_Storage.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Games_Storage.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDatabaseContext _context;
        public UnitOfWork(SqlDatabaseContext context)
        {
            _context = context;
            Games = new GameRepository(_context);
            Studios = new StudioRepository(_context);
        }

        public IGameRepository Games { get; init; }
        public IStudioRepository Studios { get; init; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
