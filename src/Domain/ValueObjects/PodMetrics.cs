namespace Domain.ValueObjects;

[method: JsonConstructor]
public sealed class PodMetrics(string label, string podSelector, double cpuUsage, double memoryUsage) : ValueObject
{
    [Required]
    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    [Required]
    [JsonPropertyName("podSelector")]
    public string PodSelector { get; init; } = podSelector;

    [Required]
    [JsonPropertyName("cpuUsage")]
    public double CpuUsage { get; init; } = cpuUsage;

    [Required]
    [JsonPropertyName("memoryUsage")]
    public double MemoryUsage { get; init; } = memoryUsage;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Label;
        yield return PodSelector;
        yield return CpuUsage;
        yield return MemoryUsage;
    }
}