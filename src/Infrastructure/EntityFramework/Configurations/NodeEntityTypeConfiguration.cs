namespace Infrastructure.EntityFramework.Configurations;

public class NodeEntityTypeConfiguration : IEntityTypeConfiguration<NodeEntity>
{
    public void Configure(EntityTypeBuilder<NodeEntity> builder)
    {
        builder.Ignore(v => v.DomainEvents);
        builder.Property(v => v.Id).IsRequired();
        builder.Property(v => v.Created);
        builder.Property(v => v.NodeSelector);
        builder.HasKey(v => v.Id);
        builder.ToTable("NodeEntity");

        builder.HasMany(v => v.Metrics)
            .WithOne()
            .HasForeignKey("NodeId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}