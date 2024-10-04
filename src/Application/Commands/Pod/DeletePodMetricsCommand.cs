namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class DeletePodMetricsCommand(Guid entityId, string? label = default) : ICommand<bool>
{
    [JsonPropertyName("label")]
    public string? Label { get; init; } = label;

    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}