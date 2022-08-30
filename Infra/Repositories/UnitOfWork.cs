using Domain.Entities;
using Infra.Contexts;
using Infra.Repositories.Interfaces;

namespace Infra.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context = null;
    private Repository<User> _userRepository = null;

    public UnitOfWork(AppDbContext context)
    {
        this._context = context;
    }

    public IRepository<User> UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new Repository<User>(_context);
            }
            return _userRepository;
        }
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}