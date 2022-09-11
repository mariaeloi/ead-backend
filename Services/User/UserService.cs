using CryptSharp;
using Domain.Constants;
using Domain.Entities;
using Domain.Enum;
using Infra.Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;

namespace Services;

public class UserService : IService<User>
{
    private const string ENTITY_NAME = EntityNameConstant.User;
    private readonly IUnitOfWork _uow;
    private readonly AuthData _auth;
    private readonly FluentValidation.IValidator<User> _validator;
    private readonly ILogService _logger;

    public UserService(IUnitOfWork uow, AuthData auth, FluentValidation.IValidator<User> validator, ILogService logger)
    {
        this._uow = uow;
        this._auth = auth;
        this._validator = validator;
        this._logger = logger;
    }

    public List<User> FindAll()
    {
        List<User> users = _uow.UserRepository.FindAll().ToList();
        if (users.Count == 0)
            throw new NotFoundException("Nenhum dado encontrado");

        return users;
    }

    public User Add(User user)
    {
        this.Validate(user);
        user.Password = Crypter.MD5.Crypt(user.Password);
        User savedUser = _uow.UserRepository.Create(user);
        _logger.Log(ActionConstant.Create, ENTITY_NAME, savedUser.Id);
        return savedUser;
    }

    public User GetById(long id)
    {
        User user = _uow.UserRepository.FindById(id);
        if (user == null)
            throw new NotFoundException("Usuário não encontrado");

        return user;
    }

    public User Update(User user)
    {
        User loggedInUser = this.GetLoggedInUser();
        if (loggedInUser.Id != user.Id)
            throw new AccessDeniedException("Você não tem permissão para atualizar este usuário");

        this.Validate(user);

        if (!user.Password.Equals(loggedInUser.Password))
            user.Password = Crypter.MD5.Crypt(user.Password);
        user.CreatedOn = loggedInUser.CreatedOn;
        user.UpdatedOn = DateTime.Now;

        User savedUser = _uow.UserRepository.Update(user);
        _logger.Log(ActionConstant.Update, ENTITY_NAME, savedUser.Id);
        return savedUser;
    }

    public void Delete(long id)
    {
        if (_uow.UserRepository.FindById(id) == null)
            throw new NotFoundException("Usuário não encontrado");

        User loggedInUser = this.GetLoggedInUser();
        if (loggedInUser.Id != id && loggedInUser.Role != UserRole.Principal)
            throw new AccessDeniedException("Você não tem permissão para remover este usuário");

        _uow.UserRepository.DeleteById(id);
        _logger.Log(ActionConstant.Delete, ENTITY_NAME, id);
    }

    public void Validate(User user)
    {
        var errors = _validator.Validate(user).ToDictionary();

        if (!errors.ContainsKey("Username"))
        {
            User userExist = _uow.UserRepository.FindOne(u => u.Id != user.Id && u.Username.ToLower().Equals(user.Username.ToLower()));
            if (userExist != null)
                errors.Add("Username", new string[] { "Este nome de usário encontra-se em uso" });
        }
        if (!errors.ContainsKey("Email"))
        {
            User userExist = _uow.UserRepository.FindOne(u => u.Id != user.Id && u.Email.ToLower().Equals(user.Email.ToLower()));
            if (userExist != null)
                errors.Add("Email", new string[] { "Este e-mail encontra-se em uso" });
        }

        if (errors.Count > 0)
            throw new ValidationException(errors);
    }

    private User GetLoggedInUser()
    {
        User loggedInUser = _auth.LoggedInUser;
        if (loggedInUser == null || loggedInUser.Active == false)
            throw new AccessDeniedException("Usuário autenticado não encontrado ou desativado");
        return loggedInUser;
    }
}