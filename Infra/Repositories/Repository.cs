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
        try
        {
            return dbSet.Where(where);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public T Create(T user)
    {
        dbSet.Add(user);
        context.SaveChanges();
        return user;
    }

    public T GetById(long id)
    {
        T? obj = dbSet.Find(id);
        return obj;
    }

    public T Update(T user)
    {
        dbSet.Update(user);
        context.SaveChanges();
        return user;
    }

    public void Delete(long id)
    {
        T? obj = dbSet.Find(id);
        dbSet.Remove(obj);
        context.SaveChanges();
    }
}
