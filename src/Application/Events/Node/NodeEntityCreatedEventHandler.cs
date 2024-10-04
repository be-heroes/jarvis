namespace Application.Events.Node;

public sealed class NodeEntityCreatedEventHandler(IMapper mapper, IMediator mediator) : IEventHandler<NodeEntityCreatedEvent>
{
    private readonly IMapper _mapper = mapper;

    private readonly IMediator _mediator = mediator;

    public async Task Handle(NodeEntityCreatedEvent @event, CancellationToken ct = default)
    {
        await _mediator.Publish(_mapper.Map<NodeEntityCreatedIntegrationEvent>(@event), ct);
    }
}