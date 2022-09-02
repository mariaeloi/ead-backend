using CryptSharp;
using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Interfaces;

namespace Services;

public class UserService : IService<User>
{
    private readonly IUnitOfWork _uow;

    public UserService(IUnitOfWork uow)
    {
        this._uow = uow;
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
        User userExist = _uow.UserRepository.FindById(user.Id);

        if(!user.Password.Equals(userExist.Password))
            user.Password = Crypter.MD5.Crypt(user.Password);

        return _uow.UserRepository.Update(user);
    }

    public void Delete(long id)
    {
        _uow.UserRepository.DeleteById(id);
    }
}