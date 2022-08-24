using System.Linq.Expressions;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class Repository<T> where T : class
{
    protected readonly AppDbContext context;

    protected readonly DbSet<T> dbSet;
    
    public Repository(AppDbContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> where)
    {
        try {
            return dbSet.Where(where);
        } catch (Exception) {
            throw;
        }
    }
}
