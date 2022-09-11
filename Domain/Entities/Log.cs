namespace Domain.Entities;

public class Log
{
    public long Id { get; } = 0;
    public long? UserId { get; set; }
    public User User { get; set; }
    public string Action { get; set; }
    public string EntityName { get; set; }
    public long EntityId { get; set; }
    public DateTime Date { get; } = DateTime.Now;

    public Log()
    {
    }

    public Log(string action, string entityName, long entityId)
    {
        this.Action = action;
        this.EntityName = entityName;
        this.EntityId = entityId;
    }
}