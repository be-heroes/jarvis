namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class DeleteNodeMetricsCommand(Guid entityId, string? label = default) : ICommand<bool>
{
    [JsonPropertyName("label")]
    public string? Label { get; init; } = label;

    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}