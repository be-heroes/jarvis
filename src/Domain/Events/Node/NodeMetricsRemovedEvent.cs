namespace Domain.Events.Node;

public sealed class NodeMetricsRemovedEvent : NodeEntityEvent
{
    public NodeMetricsRemovedEvent(NodeEntity entity, NodeMetrics metrics)
    {
        Entity = entity;
        Metrics = metrics;
    }

    public NodeMetrics Metrics { get; private set; }
}