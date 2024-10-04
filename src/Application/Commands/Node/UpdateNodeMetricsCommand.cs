namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class UpdateNodeMetricsCommand(string label, double cpuUsage, double memoryUsage, Guid entityId) : ICommand<NodeMetrics>
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