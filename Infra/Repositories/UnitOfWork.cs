using Domain.Entities;
using Infra.Contexts;
using Infra.Repositories.Interfaces;

namespace Infra.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context = null;
    private Repository<User> _userRepository = null;
    private Repository<Course> _courseRepository = null;

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

    public IRepository<Course> CourseRepository
    {
        get
        {
            if (_courseRepository == null)
            {
                _courseRepository = new Repository<Course>(_context);
            }
            return _courseRepository;
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