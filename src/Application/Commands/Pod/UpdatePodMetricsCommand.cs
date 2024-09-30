namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class UpdatePodMetricsCommand(string label, string podSelector, double cpuUsage, double memoryUsage, Guid entityId) : ICommand<PodMetrics>
{
    [JsonPropertyName("podSelector")]
    public string PodSelector { get; init; } = podSelector;

    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;

    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    [JsonPropertyName("cpuUsage")]
    public double CpuUsage { get; init; } = cpuUsage;

    [JsonPropertyName("memoryUsage")]
    public double MemoryUsage { get; init; } = memoryUsage;
}