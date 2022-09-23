using System.Linq.Expressions;
using Domain.Entities;

namespace Infra.Repositories.Interfaces;

public interface ILogRepository
{
    IEnumerable<Log> FindAll(Expression<Func<Log, bool>> predicate);
    Log Save(Log log);
}