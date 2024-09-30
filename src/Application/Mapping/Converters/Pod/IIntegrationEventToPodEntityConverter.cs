namespace Application.Mapping.Converters.Pod;

public class IIntegrationEventToPodEntityConverter(IMapper mapper, IPodService podService) : ITypeConverter<IIntegrationEvent, PodEntity>
{
    public readonly IMapper _mapper = mapper;

    public readonly IPodService _domainService = podService ?? throw new ArgumentNullException(nameof(podService));

    public PodEntity Convert(IIntegrationEvent source, PodEntity destination, ResolutionContext context)
    {
        // Simplistic conversion logic
        JsonElement? payload;

        if (source?.Payload?.ValueKind == JsonValueKind.Object)
        {
            payload = source.Payload;
        }
        else
        {
            switch (source?.Payload?.ValueKind)
            {
                case JsonValueKind.String:
                    var rawText = source.Payload.Value.GetRawText();
                    var cleanedText = rawText[1..^1].Replace("\\", "");

                    payload = JsonDocument.Parse(cleanedText).RootElement;

                    break;
                default:
                    throw new ApplicationFacadeException($"Unsupported ValueKind: {source?.Payload?.ValueKind}");
            }
        }

        if(Guid.TryParse(payload?.GetProperty("id").GetString(), out var entityId))
        {
            var getEntityTask = _domainService.GetPodEntityByIdAsync(entityId);

            getEntityTask.Wait();

            destination = getEntityTask.Result ?? throw new ApplicationFacadeException($"PodEntity with id {entityId} not found.");

            // TODO: Map the integration event payload (JsonObject) to the PodEntity
        }

        return destination;
    }
}
