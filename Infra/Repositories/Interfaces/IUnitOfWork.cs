using Domain.Entities;

namespace Infra.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> UserRepository { get; }
    IRepository<Course> CourseRepository { get; }
    IRepository<Lesson> LessonRepository { get; }
    ILogRepository LogRepository { get; }
}