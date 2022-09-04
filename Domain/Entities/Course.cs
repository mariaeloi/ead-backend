namespace Domain.Entities;

public class Course : Entity
{
    public Course()
    {
        Lessons = new List<Lesson>();
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; }  
    //public List<User> Students { get; set; }
}
