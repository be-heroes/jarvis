namespace Domain.Events.Pod;

public sealed class PodMetricsRemovedEvent : PodEntityEvent
{
    public PodMetricsRemovedEvent(PodEntity entity, PodMetrics metrics)
    {
        Entity = entity;
        Metrics = metrics;
    }

    public PodMetrics Metrics { get; private set; }
}