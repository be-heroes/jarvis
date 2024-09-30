namespace Domain.Events.Pod;

public sealed class PodMetricsAddedEvent : PodEntityEvent
{
    public PodMetricsAddedEvent(PodEntity entity, PodMetrics metrics)
    {
        Entity = entity;
        Metrics = metrics;
    }

    public PodMetrics Metrics { get; private set; }
}