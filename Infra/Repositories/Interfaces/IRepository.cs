using System.Linq.Expressions;
using Domain.Entities;

namespace Infra.Repositories.Interfaces;

public interface IRepository<T> where T : Entity
{
    IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null, Expression<Func<T, object>> order = null);
    IEnumerable<T> FindAll(Expression<Func<T, object>> include = null, Expression<Func<T, object>> order = null);
    T FindOne(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null);
    T FindById(long id, Expression<Func<T, object>> include = null);
    T Create(T entity);
    T Update(T entity);
    void Delete(T entity);
    void DeleteById(long id);
    T FindOneTracked(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null);
}