namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class UpdatePodMetricsCommand(string label, double cpuUsage, double memoryUsage, Guid entityId) : ICommand<PodMetrics>
{
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;

    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    [JsonPropertyName("cpuUsage")]
    public double CpuUsage { get; init; } = cpuUsage;

    [JsonPropertyName("memoryUsage")]
    public double MemoryUsage { get; init; } = memoryUsage;
}