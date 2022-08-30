using Domain.Entities;
using Infra.Repositories;
using Services.Interfaces;

namespace Services;

public class UserService : IService<User>
{
    private readonly UserRepository repository;

    public UserService(UserRepository repository)
    {
        this.repository = repository;
    }
    
    public List<User> FindAll()
    {
        List<User> users = repository.GetAll().ToList();
        if(users.Count == 0)
            throw new Exception("Nenhum dado encontrado.");

        return users;
    }

    public User Add(User user) {

        return repository.Create(user);

    }
}