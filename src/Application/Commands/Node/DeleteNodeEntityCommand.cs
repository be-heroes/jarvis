namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class DeleteNodeEntityCommand(Guid entityId) : ICommand<bool>
{
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}