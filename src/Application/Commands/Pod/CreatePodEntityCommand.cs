namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class CreatePodEntityCommand(string podSelector, IEnumerable<PodMetrics> metrics) : ICommand<PodEntity>
{    
    [JsonPropertyName("podSelector")]
    public string PodSelector { get; init; } = podSelector;

    [JsonPropertyName("metrics")]
    public IEnumerable<PodMetrics> Metrics { get; init; } = metrics;
}