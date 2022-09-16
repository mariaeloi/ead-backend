using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;
using Domain.Enum;
using Domain.Constants;

namespace Services;

public class LessonService
{
    private readonly IUnitOfWork _uow;
    private AuthData _auth;
    private ILogService _logger;

    public LessonService(IUnitOfWork uow, AuthData auth, ILogService logger)
    {
        this._uow = uow;
        this._auth = auth;
        this._logger = logger;
    }

    public List<Lesson> FindAll()
    {
        List<Lesson> lessons = _uow.LessonRepository.FindAll().ToList();
        if (lessons.Count == 0)
            throw new Exception("Nenhuma lição encontrada.");

        return lessons;
    }

    public Lesson Add(Lesson lesson, long courseId)
    {
        Course course = _uow.CourseRepository.FindById(courseId);
        if (course == null)
            throw new NotFoundException("Não existe Curso com este ID.");

        if (_auth.LoggedInUser.Role != UserRole.Teacher || (_auth.LoggedInUser.Id != course.OwnerId))
            throw new AccessDeniedException("Somente o professor e proprietário deste curso pode adicionar aula a ele.");
            
        lesson.CourseId = courseId;
        course.Lessons.Add(lesson);
        Lesson savedLesson = _uow.LessonRepository.Create(lesson);
        _logger.Log(ActionConstant.Create, EntityNameConstant.Lesson, lesson.Id);
        return savedLesson;
    }

    public Lesson GetById(long id)
    {
        Lesson lesson = _uow.LessonRepository.FindById(id);
        if (lesson == null)
            throw new NotFoundException("Não existe aula com este ID.");

        return lesson; 
    }

    public Lesson Update(Lesson lesson)
    {   
        if (GetById(lesson.Id) is null)
            throw new NotFoundException("Não existe aula com este ID.");
            
        long courseId = GetById(lesson.Id).CourseId; 
        Course course = _uow.CourseRepository.FindById(courseId);

        if (_auth.LoggedInUser.Id != course.OwnerId)
            throw new AccessDeniedException("Somente o professor e proprietário desta aula pode edita-la.");
        
        lesson.UpdatedOn = DateTime.Now;
        lesson.CourseId = courseId;
        _logger.Log(ActionConstant.Update, EntityNameConstant.Lesson, lesson.Id); 
        return _uow.LessonRepository.Update(lesson);
    }

    public void Delete(long id)
    {
        _uow.LessonRepository.DeleteById(id);
    }

    // public List<Lesson> GetLessonsBycoureId(long id)
    // {
    //     return T;
    // }
}