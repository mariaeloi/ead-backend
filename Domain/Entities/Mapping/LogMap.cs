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
            .IsRequired();

        builder.Property(l => l.Action)
            .HasColumnName("action")
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(l => l.EntityName)
            .HasColumnName("entity_name")
            .HasColumnType("varchar")
            .HasMaxLength(10)
            .IsRequired();
        
        builder.HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .IsRequired();
        
        builder.Property(l => l.EntityId)
            .HasColumnName("entity_id")
            .HasColumnType("bigint")
            .IsRequired();
    }
}