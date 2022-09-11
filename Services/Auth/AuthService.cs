using CryptSharp;
using Domain.Constants;
using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Exceptions;
using Services.Interfaces;

namespace Services;

public class AuthService
{
    private const string ENTITY_NAME = EntityNameConstant.User;
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;
    private readonly ILogService _logger;

    public AuthService(IUnitOfWork uow, ITokenService tokenService, ILogService logger)
    {
        this._uow = uow;
        this._tokenService = tokenService;
        this._logger = logger;
    }

    public dynamic Authenticate(User user)
    {
        User userExist = _uow.UserRepository.FindOne(u => u.Active && u.Username.ToLower().Equals(user.Username.ToLower()));
        if(userExist == null)
            throw new NotFoundException();

        if(!Crypter.CheckPassword(user.Password, userExist.Password))
            throw new BadCredentialsException();

        var token = _tokenService.GenerateToken(userExist);
        _logger.Log(ActionConstant.Login, ENTITY_NAME, userExist.Id);
        return new {
            user = userExist,
            token = token
        };
    }
}
