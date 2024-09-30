namespace Application.Events.Pod;

public sealed class PodEntityCreatedEventHandler(IMapper mapper, IMediator mediator) : IEventHandler<PodEntityCreatedEvent>
{
    private readonly IMapper _mapper = mapper;

    private readonly IMediator _mediator = mediator;

    public async Task Handle(PodEntityCreatedEvent @event, CancellationToken ct = default)
    {
        await _mediator.Publish(_mapper.Map<PodEntityCreatedIntegrationEvent>(@event), ct);
    }
}