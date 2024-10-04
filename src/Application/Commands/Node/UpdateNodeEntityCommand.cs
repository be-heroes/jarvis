namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class UpdateNodeEntityCommand(NodeEntity entity) : ICommand<NodeEntity>
{
    [JsonPropertyName("entity")] 
    public NodeEntity Entity { get; init; } = entity;
}