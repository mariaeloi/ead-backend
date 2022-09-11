using CryptSharp;
using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;

namespace Services;

public class UserService : IService<User>
{
    private readonly IUnitOfWork _uow;
    private readonly AuthData _auth;
    private readonly FluentValidation.IValidator<User> _validator;

    public UserService(IUnitOfWork uow, AuthData auth, FluentValidation.IValidator<User> validator)
    {
        this._uow = uow;
        this._auth = auth;
        this._validator = validator;
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
        return _uow.UserRepository.Create(user);
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
        User loggedInUser = _auth.LoggedInUser;
        if (loggedInUser.Id != user.Id && loggedInUser.Role != 0)
            throw new AccessDeniedException("Você não tem permissão para atualizar este usuário");

        this.Validate(user);

        if (!user.Password.Equals(loggedInUser.Password))
            user.Password = Crypter.MD5.Crypt(user.Password);
        user.CreatedOn = loggedInUser.CreatedOn;
        user.UpdatedOn = DateTime.Now;

        return _uow.UserRepository.Update(user);
    }

    public void Delete(long id)
    {
        User loggedInUser = _auth.LoggedInUser;
        if (loggedInUser.Id != id && loggedInUser.Role != 0)
            throw new AccessDeniedException("Você não tem permissão para remover este usuário");

        _uow.UserRepository.DeleteById(id);
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
}