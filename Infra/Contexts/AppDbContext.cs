using Domain.Entities.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new CourseMap());
        modelBuilder.ApplyConfiguration(new LessonMap());

        base.OnModelCreating(modelBuilder);
    }
}