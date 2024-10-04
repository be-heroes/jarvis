namespace Domain.Events.Node;

public abstract class NodeEntityEvent : IDomainEvent
{
    public NodeEntity? Entity { get; protected set; }
}