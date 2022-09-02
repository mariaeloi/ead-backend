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

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
    {
        return dbSet.Where(predicate);
    }

    public IEnumerable<T> FindAll()
    {
        return this.FindAll(x => x.Active);
    }
    
    public T FindOne(Expression<Func<T, bool>> predicate)
    {
        T entity = dbSet.FirstOrDefault(predicate);
        context.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public T FindById(long id)
    {
        return this.FindOne(x => (x.Active && (x.Id == id)));
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
        // dbSet.Update(entity);
        context.SaveChanges();
    }

    public void DeleteById(long id)
    {
        T entity = dbSet.Find(id);
        this.Delete(entity);
    }
}
