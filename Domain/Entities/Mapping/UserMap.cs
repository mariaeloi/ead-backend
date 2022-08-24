using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("id")
            .HasColumnType("bigint")
            .IsRequired();

        builder.Property(u => u.CreatedOn)
            .HasColumnName("created_on")
            .HasColumnType("timestamp")
            // .HasDefaultValue(DateTime.Now)
            .IsRequired();

        builder.Property(u => u.UpdatedOn)
            .HasColumnName("updated_on")
            .HasColumnType("timestamp");

        builder.Property(u => u.Active)
            .HasColumnName("active")
            .HasColumnType("boolean")
            // .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Username)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnName("password")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Role)
            .HasColumnName("role")
            .HasColumnType("varchar")
            .HasMaxLength(10)
            .IsRequired();
    }
}
