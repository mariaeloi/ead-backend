using System.Linq.Expressions;
using Domain.Entities;
using Infra.Contexts;
using Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext context;
        private readonly DbSet<Log> dbSet;

        public LogRepository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<Log>();
        }

        public IEnumerable<Log> FindAll(Expression<Func<Log, bool>> predicate)
        {
            return dbSet.Where(predicate).Include(l => l.User);
        }

        public Log Save(Log log)
        {
            dbSet.Add(log);
            context.SaveChanges();
            return log;
        }
    }
}