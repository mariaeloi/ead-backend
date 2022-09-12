using Services.Interfaces;
using Domain.Entities;
using Infra.Repositories.Interfaces;
using Services.Exceptions;

namespace Services.Logger;

public class LogService : ILogService
{
    private readonly IUnitOfWork _uow;
    private readonly AuthData _auth;

    public LogService(IUnitOfWork uow, AuthData auth)
    {
        this._uow = uow;
        this._auth = auth;
    }

    public List<Log> FindAll()
    {
        List<Log> logs = _uow.LogRepository.FindAll(l => true).ToList();
        if (logs.Count == 0)
            throw new NotFoundException("Nenhum dado encontrado");

        return logs;
    }

    public void Log(string action, string entityName, long entityId)
    {
        Log log = new Log(action, entityName, entityId);

        // Não verifica se o usuário autenticado está ativo, pois o log falharia
        // caso o usuário tivesse acabado de desativar a sua conta
        var loggedInUserTracked = _auth.LoggedInUserTracked;
        if (loggedInUserTracked != null)
            log.User = loggedInUserTracked;
        
        _uow.LogRepository.Save(log);
    }
}