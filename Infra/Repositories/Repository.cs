using System.Linq.Expressions;
using Domain.Entities;
using Infra.Contexts;
using Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext context;

    protected readonly DbSet<T> dbSet;

    public Repository(AppDbContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
    {
        if (include == null)
            return dbSet.Where(predicate);
        else
            return dbSet.Where(predicate).Include(include);
    }

    public IEnumerable<T> FindAll(Expression<Func<T, object>> include = null)
    {
        return this.FindAll(x => x.Active, include);
    }
    
    public T FindOne(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
    {
        // T entity = dbSet.Include(include).FirstOrDefault(predicate);
        T entity;
        if (include == null)
            entity = dbSet.Where(predicate).FirstOrDefault();
        else
            entity = dbSet.Where(predicate).Include(include).FirstOrDefault();

        if(entity != null)
            context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public T FindById(long id, Expression<Func<T, object>> include = null)
    {
        return this.FindOne(x => (x.Active && (x.Id == id)), include);
    }

    public T Create(T entity)
    {
        dbSet.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public T Update(T entity)
    {
        dbSet.Update(entity);
        context.SaveChanges();
        return entity;
    }

    public void Delete(T entity)
    {
        entity.Active = false;
        entity.UpdatedOn = DateTime.Now;
        dbSet.Update(entity);
        context.SaveChanges();
    }

    public void DeleteById(long id)
    {
        T entity = dbSet.Find(id);
        this.Delete(entity);
    }

    public T FindOneTracked(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
    {
        if (include == null)
            return dbSet.Where(predicate).FirstOrDefault();
        else
            return dbSet.Where(predicate).Include(include).FirstOrDefault();
    }
}
