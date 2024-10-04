namespace Application.Mapping.Converters.Node;

public class IIntegrationEventToNodeEntityConverter(IMapper mapper, INodeService nodeService) : ITypeConverter<IIntegrationEvent, NodeEntity>
{
    public readonly IMapper _mapper = mapper;

    public readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public NodeEntity Convert(IIntegrationEvent source, NodeEntity destination, ResolutionContext context)
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
            var getEntityTask = _nodeService.GetNodeEntityByIdAsync(entityId);

            getEntityTask.Wait();

            destination = getEntityTask.Result ?? throw new ApplicationFacadeException($"NodeEntity with id {entityId} not found.");

            // TODO: Map the integration event payload (JsonObject) to the NodeEntity
        }

        return destination;
    }
}
