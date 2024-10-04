namespace Domain.Aggregates;

public sealed class NodeEntity : Entity<Guid>, IAggregateRoot
{
    private readonly List<NodeMetrics> _metrics = [];

    public NodeEntity()
    {
        var evt = new NodeEntityCreatedEvent(this);

        AddDomainEvent(evt);
    }

    public NodeEntity(string nodeSelector, DateTime? created) : this()
    {
        Created = created ?? DateTime.UtcNow;
        NodeSelector = nodeSelector;
    }

    public IEnumerable<NodeMetrics> Metrics => _metrics.AsReadOnly();

    public DateTime Created { get; } = DateTime.UtcNow;

    public string NodeSelector { get; } = string.Empty;

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return [];
    }

    public void AddNodeMetrics(NodeMetrics metrics)
    {
        _metrics.Add(metrics);

        var evt = new NodeMetricsAddedEvent(this, metrics);

        AddDomainEvent(evt);
    }

    public void AddNodeMetrics(IEnumerable<NodeMetrics> metrics)
    {
        foreach (var obj in metrics)
            AddNodeMetrics(obj);
    }

    public void RemoveNodeMetrics(NodeMetrics metrics)
    {
        _metrics.Remove(metrics);

        var evt = new NodeMetricsRemovedEvent(this, metrics);

        AddDomainEvent(evt);
    }

    public void RemoveNodeMetrics(IEnumerable<NodeMetrics> metrics)
    {
        foreach (var obj in metrics)
            RemoveNodeMetrics(obj);
    }
}