using System.Text.Json.Serialization;
using Domain.Enum;

namespace Domain.Entities;

public class User : Entity
{
    public User()
    {
        this.Courses = new HashSet<Course>();
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    [JsonIgnore]
    public virtual ICollection<Course> Courses { get; set; }
}
