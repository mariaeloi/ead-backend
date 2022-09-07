using Domain.Entities;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Services;

public class AuthData
{
    private readonly IHttpContextAccessor _accessor;

    public AuthData(IHttpContextAccessor accessor, IUnitOfWork uow)
    {
        this._accessor = accessor;

        this.LoggedInUser =  (this.Username is null) ? new User()
            : uow.UserRepository.FindOne(u => u.Active && u.Username.ToLower().Equals(this.Username.ToLower()));
    }

    public string? Username
    {
        get
        {
            var context = _accessor.HttpContext;
            if(context is not null)
            {
                var identity = context.User.Identity;
                if(identity is not null)
                    return identity.Name;
            }
            return null;
        }
    }

    public User LoggedInUser { get; }
}
