using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain.Entities;

public abstract class Log
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public ActionEnum Action { get; set; }
    public EntityEnum EntityType { get; set; }
    public long EntityId { get; set; }
    public Entity Entity { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}