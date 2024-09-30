namespace Domain.Events.Pod;

public abstract class PodEntityEvent : IDomainEvent
{
    public PodEntity? Entity { get; protected set; }
}