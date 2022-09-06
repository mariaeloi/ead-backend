using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping;

public class LessonMap : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("id")
            .HasColumnType("bigint")
            .IsRequired();

        builder.Property(u => u.CreatedOn)
            .HasColumnName("created_on")
            .HasColumnType("timestamp")
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

        builder.Property(u => u.UpdatedOn)
            .HasColumnName("updated_on")
            .HasColumnType("timestamp");

        builder.Property(u => u.Active)
            .HasColumnName("active")
            .HasColumnType("boolean")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();    

        builder.Property(x => x.Link)
            .HasColumnName("link")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(u => u.Link).IsUnique();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar")
            .HasMaxLength(150);

        builder.Property(x => x.Order)
            .HasColumnName("order")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(c => c.Course)
            .WithMany(l => l.Lessons)
            .HasForeignKey(d => d.CourseId)
            .HasConstraintName("FK_Lesson_Course_CourseID");
    }
}
