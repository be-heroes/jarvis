namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class DeletePodEntityCommand(Guid entityId) : ICommand<bool>
{
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}