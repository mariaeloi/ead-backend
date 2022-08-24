using Domain.Entities;
using Infra.Contexts;

namespace Infra.Repositories;

public class UserRepository: Repository<User>
{
    public UserRepository(AppDbContext context)
        : base(context) { }

    public IEnumerable<User> GetAll()
    {
        return Query(x => x.Active);
    }
}
