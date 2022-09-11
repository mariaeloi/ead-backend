using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;
using Domain.Enum;

namespace Services;

public class CourseService : IService<Course>
{
    private readonly IUnitOfWork _uow;
    private AuthData _auth;

    public CourseService(IUnitOfWork uow, AuthData auth)
    {
        this._uow = uow;
        this._auth = auth;
    }

    public List<Course> FindAll()
    {
        List<Course> courses = _uow.CourseRepository.FindAll().ToList();
        if (courses.Count == 0)
            throw new Exception("Nenhum curso encontrado.");

        foreach (var course in courses)
        {
            course.Lessons = _uow.LessonRepository.FindAll(l => (l.Active && (l.CourseId == course.Id))).ToList();
        }
        return courses;
    }

    public Course Add(Course course)
    {
        if (_auth.LoggedInUser.Role != UserRole.Teacher) //Verifica o cargo do usuário logado. Se não for professor, não pode criar curso.
            throw new AccessDeniedException("Somente Professores podem criar cursos!");
        
        course.OwnerId = _auth.LoggedInUser.Id;
        return _uow.CourseRepository.Create(course);
    }

    public Course GetById(long id)
    {
        Course course = _uow.CourseRepository.FindById(id);
        if (course == null)
            throw new Exception("Não existe Curso com este ID.");

        //Busca as lições ativas do respectivo curso.
        course.Lessons = _uow.LessonRepository.FindAll(l => (l.Active && (l.CourseId == course.Id))).ToList();
        return course;
    }

    public Course Update(Course course)
    {
        Course courseFull = GetById(course.Id);
        if (_auth.LoggedInUser.Id != courseFull.OwnerId)
            throw new AccessDeniedException("Você não pode editar um curso que não é proprietário.");

        course.UpdatedOn = DateTime.Now;
        course.OwnerId = courseFull.OwnerId; 
        course.CreatedOn = courseFull.CreatedOn;  
        return _uow.CourseRepository.Update(course);
    }

    public void Delete(long id)
    {
        Course course = GetById(id);
        if (_auth.LoggedInUser.Id != course.OwnerId)
            throw new AccessDeniedException("Você não tem permissão para deletar este curso.");

        _uow.CourseRepository.DeleteById(id);
    }
}
