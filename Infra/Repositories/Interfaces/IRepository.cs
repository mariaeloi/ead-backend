using System.Linq.Expressions;
using Domain.Entities;

namespace Infra.Repositories.Interfaces;

public interface IRepository<T> where T : Entity
{
    IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
    IEnumerable<T> FindAll();
    T FindOne(Expression<Func<T, bool>> predicate);
    T FindById(long id);
    T Create(T entity);
    T Update(T entity);
    void Delete(T entity);
    void DeleteById(long id);
}