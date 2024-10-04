namespace Domain.Events.Node;

public sealed class NodeMetricsAddedEvent : NodeEntityEvent
{
    public NodeMetricsAddedEvent(NodeEntity entity, NodeMetrics metrics)
    {
        Entity = entity;
        Metrics = metrics;
    }

    public NodeMetrics Metrics { get; private set; }
}