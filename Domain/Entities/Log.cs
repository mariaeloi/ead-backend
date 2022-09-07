namespace Domain.Entities;

public class Log
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public string Action { get; set; }
    public string EntityName { get; set; }
    public long EntityId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}