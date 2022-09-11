using CryptSharp;
using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;

namespace Services;

public class AuthService
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;

    public AuthService(IUnitOfWork uow, ITokenService tokenService)
    {
        this._uow = uow;
        this._tokenService = tokenService;
    }

    public dynamic Authenticate(User user)
    {
        User userExist = _uow.UserRepository.FindOne(u => u.Active && u.Username.ToLower().Equals(user.Username.ToLower()));
        if(userExist == null)
            throw new NotFoundException();

        if(!Crypter.CheckPassword(user.Password, userExist.Password))
            throw new BadCredentialsException();

        var token = _tokenService.GenerateToken(userExist);
        return new {
            user = userExist,
            token = token
        };
    }
}
