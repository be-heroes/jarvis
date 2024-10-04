namespace Domain.Events.Node;

public sealed class NodeEntityCreatedEvent : NodeEntityEvent
{
    public NodeEntityCreatedEvent(NodeEntity entity)
    {
        Entity = entity;
    }
}