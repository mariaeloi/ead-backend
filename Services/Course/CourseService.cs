using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Interfaces;

namespace Services;

public class CourseService : IService<Course>
{
    private readonly IUnitOfWork _uow;

    public CourseService(IUnitOfWork uow)
    {
        this._uow = uow;
    }

    public List<Course> FindAll()
    {
        List<Course> courses = _uow.CourseRepository.FindAll().ToList();
        if (courses.Count == 0)
            throw new Exception("Nenhum dado encontrado.");

        return courses;
    }

    public Course Add(Course course)
    {
        return _uow.CourseRepository.Create(course);
    }

    public Course GetById(long id)
    {
        return _uow.CourseRepository.FindById(id);
    }

    public Course Update(Course course)
    {
        return _uow.CourseRepository.Update(course);
    }

    public void Delete(long id)
    {
        _uow.CourseRepository.DeleteById(id);
    }
}
