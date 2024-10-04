namespace Domain.ValueObjects;

[method: JsonConstructor]
public sealed class NodeMetrics(string label, double cpuTotal, double memoryTotal) : ValueObject
{
    [Required]
    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    [Required]
    [JsonPropertyName("cpuTotal")]
    public double CpuTotal { get; init; } = cpuTotal;

    [Required]
    [JsonPropertyName("memoryTotal")]
    public double MemoryTotal { get; init; } = memoryTotal;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Label;
        yield return CpuTotal;
        yield return MemoryTotal;
    }
}