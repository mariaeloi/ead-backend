namespace Domain.Entities;

public class Course : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Lesson> Lessons { get; set; }  
    public List<User> Students { get; set; }
    public User Owner { get; set; }
}
