using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping;

public class CourseMap : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");

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
        builder.HasIndex(u => u.Title).IsUnique();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.HasMany(u => u.Students)
            .WithMany(u => u.Courses)
            .UsingEntity(j => j.ToTable("CousersStudents"));

        builder.HasOne(u => u.Owner)
            .WithMany()
            .HasForeignKey(u => u.OwnerId);
    }
}
