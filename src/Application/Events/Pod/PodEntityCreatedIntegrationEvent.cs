namespace Application.Events.Pod;

public class PodEntityCreatedIntegrationEvent : IIntegrationEvent
{
    public string Id { get; init; } = string.Empty;

    public string CorrelationId { get; init; } = string.Empty;

    public DateTime CreationDate { get; init; }

    public string SchemaVersion { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;

    public JsonElement? Payload { get; init; }
}