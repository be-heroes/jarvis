namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class CreateNodeEntityCommand(string nodeSelector, IEnumerable<NodeMetrics> metrics) : ICommand<NodeEntity>
{    
    [JsonPropertyName("nodeSelector")]
    public string NodeSelector { get; init; } = nodeSelector;

    [JsonPropertyName("metrics")]
    public IEnumerable<NodeMetrics> Metrics { get; init; } = metrics;
}