namespace Domain.Aggregates;

public sealed class PodEntity : Entity<Guid>, IAggregateRoot
{
    private readonly List<PodMetrics> _metrics = [];

    public PodEntity()
    {
        var evt = new PodEntityCreatedEvent(this);

        AddDomainEvent(evt);
    }

    public PodEntity(string podSelector, DateTime? created) : this()
    {
        Created = created ?? DateTime.UtcNow;
        PodSelector = podSelector;
    }

    public IEnumerable<PodMetrics> Metrics => _metrics.AsReadOnly();

    public DateTime Created { get; } = DateTime.UtcNow;

    public string PodSelector { get; } = string.Empty;

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return [];
    }

    public void AddPodMetrics(PodMetrics metrics)
    {
        _metrics.Add(metrics);

        var evt = new PodMetricsAddedEvent(this, metrics);

        AddDomainEvent(evt);
    }

    public void AddPodMetrics(IEnumerable<PodMetrics> metrics)
    {
        foreach (var obj in metrics)
            AddPodMetrics(obj);
    }

    public void RemovePodMetric(PodMetrics metrics)
    {
        _metrics.Remove(metrics);

        var evt = new PodMetricsRemovedEvent(this, metrics);

        AddDomainEvent(evt);
    }

    public void RemovePodMetric(IEnumerable<PodMetrics> metrics)
    {
        foreach (var obj in metrics)
            RemovePodMetric(obj);
    }
}