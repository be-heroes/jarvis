namespace Infrastructure.EntityFramework.Configurations;

public class PodEntityTypeConfiguration : IEntityTypeConfiguration<PodEntity>
{
    public void Configure(EntityTypeBuilder<PodEntity> builder)
    {
        builder.Ignore(v => v.DomainEvents);
        builder.Property(v => v.Id).IsRequired();
        builder.Property(v => v.Created);
        builder.Property(v => v.PodSelector);
        builder.HasKey(v => v.Id);
        builder.ToTable("PodEntity");

        builder.OwnsMany(
            p => p.Metrics, a =>
            {
                a.WithOwner().HasForeignKey("OwnerId");
                a.Property<Guid>("Id");
                a.HasKey("Id");
            });
    }
}