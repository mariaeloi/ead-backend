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

    public IEnumerable<T> FindAll()
    {
        return dbSet.Where(x => x.Active);
    }

    public T FindById(long id)
    {
        T entity = dbSet.Where(x => (x.Active && (x.Id == id))).FirstOrDefault();
        // T entity = dbSet.Find(id);
        return entity;
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
        dbSet.Update(entity);
        // dbSet.Remove(entity);
        context.SaveChanges();
    }

    public void DeleteById(long id)
    {
        T entity = dbSet.Find(id);
        this.Delete(entity);
    }
}
