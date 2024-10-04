namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class GetNodeEntityByNodeSelectorCommand(string nodeSelector) : ICommand<NodeEntity?>
{
    [JsonPropertyName("nodeSelector")]
    public string NodeSelector { get; init; } = nodeSelector;
}