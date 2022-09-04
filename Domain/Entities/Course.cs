namespace Domain.Entities;

public class Course : Entity
{
    public Course()
    {
        this.Lessons = new HashSet<Lesson>();
        this.Users = new HashSet<User>();
    }
    public string Title { get; set; }
    public string Description { get; set; }
    //public long OwnerId { get; set; }
   
    public virtual ICollection<Lesson> Lessons { get; set; }
    public virtual ICollection<User> Users { get; set; }
    //public virtual User User { get; set; }
}
