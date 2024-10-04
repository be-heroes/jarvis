namespace Domain.ValueObjects;

[method: JsonConstructor]
public sealed class NodeMetrics(string label, double cpuTotal, double memoryTotal) : Metrics(label)
{
    [Required]
    [JsonPropertyName("cpuTotal")]
    public double CpuTotal { get; init; } = cpuTotal;

    [Required]
    [JsonPropertyName("memoryTotal")]
    public double MemoryTotal { get; init; } = memoryTotal;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return base.GetAtomicValues();
        yield return CpuTotal;
        yield return MemoryTotal;
    }
}