namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class GetPodEntityByPodSelectorCommand(string podSelector) : ICommand<PodEntity?>
{
    [JsonPropertyName("podSelector")]
    public string PodSelector { get; init; } = podSelector;
}