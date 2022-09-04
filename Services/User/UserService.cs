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

    public UserService(IUnitOfWork uow, AuthData auth)
    {
        this._uow = uow;
        this._auth = auth;
    }

    public List<User> FindAll()
    {
        List<User> users = _uow.UserRepository.FindAll().ToList();
        if (users.Count == 0)
            throw new Exception("Nenhum dado encontrado.");

        return users;
    }

    public User Add(User user)
    {
        user.Password = Crypter.MD5.Crypt(user.Password);
        return _uow.UserRepository.Create(user);
    }

    public User GetById(long id)
    {
        return _uow.UserRepository.FindById(id);
    }

    public User Update(User user)
    {
        User loggedInUser = _auth.LoggedInUser;
        if(loggedInUser.Id != user.Id)
            throw new AccessDeniedException("Você não tem permissão para atualizar este usuário");

        if(!user.Password.Equals(loggedInUser.Password))
            user.Password = Crypter.MD5.Crypt(user.Password);

        return _uow.UserRepository.Update(user);
    }

    public void Delete(long id)
    {
        _uow.UserRepository.DeleteById(id);
    }
}