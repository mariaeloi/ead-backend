using Domain.Entities;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Services;

public class AuthData
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IUnitOfWork _uow;

    public AuthData(IHttpContextAccessor accessor, IUnitOfWork uow)
    {
        this._accessor = accessor;
        this._uow = uow;
    }

    public long UserId
    {
        get
        {
            var context = _accessor.HttpContext;
            if(context is not null)
            {
                var identity = context.User.Identity;
                if(identity is not null)
                {
                    var name = (identity.Name is null) ? "0" : identity.Name;
                    return long.Parse(name, 0);
                }
            }
            return 0;
        }
    }

    public User LoggedInUser
    {
        get
        {
            return (this.UserId == 0) ? new User()
                : this._uow.UserRepository.FindOne(u => u.Id == this.UserId);
        }
    }

    public User? LoggedInUserTracked
    {
        get
        {
            return (this.UserId == 0) ? null
                : this._uow.UserRepository.FindOneTracked(u => u.Id == this.UserId);
        }
    }
}
