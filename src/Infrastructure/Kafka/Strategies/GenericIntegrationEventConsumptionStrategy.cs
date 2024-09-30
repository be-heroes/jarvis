namespace Infrastructure.Kafka.Strategies;

// TODO: Update kafka package
public sealed class GenericIntegrationEventConsumptionStrategy(IMapper mapper, IApplicationFacade applicationFacade) : ConsumtionStrategy(mapper, applicationFacade)
{
    public override async Task Apply(ConsumeResult<string, string> target, CancellationToken ct = default)
    {
        var payload = target.Message.Value;

        if (!string.IsNullOrEmpty(payload))
        {
            var @event = JsonSerializer.Deserialize<IntegrationEvent>(payload);
            var command = _mapper.Map<ICommand<IAggregateRoot>>(@event);

            if (command != null) 
                await _applicationFacade.Execute(command, ct);
        }
    }
}