namespace Application.Mapping.Converters;

public class IIntegrationEventToIAggregateRootConverter(IMapper mapper) : ITypeConverter<IIntegrationEvent, IAggregateRoot>
{
    private readonly IMapper _mapper = mapper;

    public IAggregateRoot Convert(IIntegrationEvent source, IAggregateRoot destination, ResolutionContext context)
    {
        return source.Type switch
        {
            "externally_mutated_pod_entity_integration_event" => _mapper.Map<PodEntity>(source),
            _ => throw new NotSupportedException($"The integration event type {source.Type} is not supported.")
        };
    }
}
