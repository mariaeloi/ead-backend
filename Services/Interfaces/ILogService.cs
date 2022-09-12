using Domain.Entities;

namespace Services.Interfaces;

public interface ILogService
{
    List<Log> FindAll();
    void Log(string action, string entityName, long entityId);
}