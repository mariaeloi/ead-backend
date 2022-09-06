using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping;

public class LogMap : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("logs");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasColumnName("id")
            .HasColumnType("bigint")
            .IsRequired();

        builder.Property(l => l.Date)
            .HasColumnName("date")
            .HasColumnType("timestamp")
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

        builder.Property(l => l.Action)
            .HasColumnName("action")
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(l => l.EntityType)
            .HasColumnName("action")
            .HasColumnType("varchar")
            .HasMaxLength(10)
            .IsRequired();
        
        builder.HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId);
        
        builder.HasOne(l => l.Entity)
            .WithMany()
            .HasForeignKey(l => l.EntityId);
    }
}