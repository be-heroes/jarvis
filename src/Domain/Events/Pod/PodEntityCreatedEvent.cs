namespace Domain.Events.Pod;

public sealed class PodEntityCreatedEvent : PodEntityEvent
{
    public PodEntityCreatedEvent(PodEntity entity)
    {
        Entity = entity;
    }
}