using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;
using Domain.Enum;
using Domain.Constants;

namespace Services;

public class CourseService : IService<Course>
{
    private readonly IUnitOfWork _uow;
    private AuthData _auth;
    private ILogService _logger;
    private UserService _userService;
    private readonly FluentValidation.IValidator<Course> _validator;

    public CourseService(IUnitOfWork uow, AuthData auth, ILogService logger, UserService userService, FluentValidation.IValidator<Course> validator)
    {
        this._uow = uow;
        this._auth = auth;
        this._logger = logger;
        this._userService = userService;
        this._validator = validator;
    }

    public List<Course> FindAll()
    {
        List<Course> courses = _uow.CourseRepository.FindAll(c => c.Students).ToList();
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

        this.Validate(course);

        Course savedCourse = _uow.CourseRepository.Create(course);
        _logger.Log(ActionConstant.Create, EntityNameConstant.Course, savedCourse.Id);
        return savedCourse;
    }

    public Course GetById(long id)
    {
        Course course = _uow.CourseRepository.FindById(id, c => c.Students);
        if (course == null)
            throw new NotFoundException("Não existe Curso com este ID.");

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

         this.Validate(course); 
        
        Course savedCourse = _uow.CourseRepository.Update(course);
        _logger.Log(ActionConstant.Update, EntityNameConstant.Course, savedCourse.Id);
        return savedCourse;
    }

    public void Delete(long id)
    {
        Course course = _uow.CourseRepository.FindById(id);
        if (course == null)
            throw new NotFoundException("Não existe Curso com este ID.");

        if (_auth.LoggedInUser.Id != course.OwnerId)
            throw new AccessDeniedException("Você não tem permissão para deletar este curso.");

        _uow.CourseRepository.DeleteById(id);
        _logger.Log(ActionConstant.Delete, EntityNameConstant.Course, id);
    }

    public void Subscribe(long idCourse)
    {
        User loggedInUser = this._userService.GetLoggedInUser();
        Course course = this.GetById(idCourse);
        course.Students.Add(loggedInUser);
        _uow.CourseRepository.Update(course);
        _logger.Log(ActionConstant.Subscribe, EntityNameConstant.Course, course.Id);
    }

    public void Unsubscribe(long idCourse, long idStudent)
    {
        Course course = this.GetById(idCourse);
        User loggedInUser = this._userService.GetLoggedInUser();
        if (loggedInUser.Id != idStudent && loggedInUser.Id != course.OwnerId)
            throw new AccessDeniedException("Você não tem permissão para cancelar a matrícula deste usuário");

        _userService.UnsubscribeCourse(idCourse, idStudent);
        _logger.Log(ActionConstant.Unsubscribe, EntityNameConstant.Course, idCourse);
    }

    public void Validate(Course course)
    {
        var errors = _validator.Validate(course).ToDictionary();

        if (!errors.ContainsKey("Title"))
        {
            Course courseExist = _uow.CourseRepository.FindOne(c => c.Id != course.Id && c.Title.ToLower().Equals(course.Title.ToLower()));
            if (courseExist != null)
                errors.Add("Title", new string[] { "Já existe um Curso com este Título." });
        }

        if (errors.Count > 0)
            throw new ValidationException(errors);
    }
}
