namespace Infrastructure.EntityFramework.Configurations;

public class MetricsTypeConfiguration : IEntityTypeConfiguration<Domain.ValueObjects.Metrics>
{
    public void Configure(EntityTypeBuilder<Domain.ValueObjects.Metrics> builder)
    {
        builder.HasDiscriminator<string>("MetricType")
            .HasValue<Domain.ValueObjects.NodeMetrics>("Node")
            .HasValue<Domain.ValueObjects.PodMetrics>("Pod");

        builder.HasKey(v => v.Label);
    }
}