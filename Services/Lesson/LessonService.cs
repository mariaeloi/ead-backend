using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Interfaces;

namespace Services;

public class LessonService : IService<Lesson>
{
    private readonly IUnitOfWork _uow;

    public LessonService(IUnitOfWork uow)
    {
        this._uow = uow;
    }

    public List<Lesson> FindAll()
    {
        List<Lesson> lessons = _uow.LessonRepository.FindAll().ToList();
        if (lessons.Count == 0)
            throw new Exception("Nenhum dado encontrado.");

        return lessons;
    }

    public Lesson Add(Lesson lesson)
    {
        return _uow.LessonRepository.Create(lesson);
    }

    public Lesson GetById(long id)
    {
        return _uow.LessonRepository.FindById(id);
    }

    public Lesson Update(Lesson lesson)
    {
        return _uow.LessonRepository.Update(lesson);
    }

    public void Delete(long id)
    {
        _uow.LessonRepository.DeleteById(id);
    }
}