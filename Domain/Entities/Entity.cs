namespace Domain.Entities;

public abstract class Entity
{
    public long Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? UpdatedOn { get; set; }
    public bool Active { get; set; } = true;
}
