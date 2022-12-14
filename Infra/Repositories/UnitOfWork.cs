using Domain.Entities;
using Infra.Contexts;
using Infra.Repositories.Interfaces;

namespace Infra.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context = null;
    private Repository<User> _userRepository = null;
    private Repository<Course> _courseRepository = null;
    private Repository<Lesson> _lessonRepository = null;
    private ILogRepository _logRepository = null;

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

    public IRepository<Lesson> LessonRepository
    {
        get
        {
            if (_lessonRepository == null)
            {
                _lessonRepository = new Repository<Lesson>(_context);
            }
            return _lessonRepository;
        }
    }

    public ILogRepository LogRepository
    {
        get
        {
            if (_logRepository == null)
            {
                _logRepository = new LogRepository(_context);
            }
            return _logRepository;
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