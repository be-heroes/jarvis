namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class DeletePodMetricsCommand(Guid entityId, string podSelector, string? label = default) : ICommand<bool>
{
    [JsonPropertyName("podSelector")]
    public string PodSelector { get; init; } = podSelector;

    [JsonPropertyName("label")]
    public string? Label { get; init; } = label;

    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}