namespace Domain.ValueObjects;

[method: JsonConstructor]
public sealed class PodMetrics(string label, double cpuUsage, double memoryUsage) : Metrics(label)
{
    [Required]
    [JsonPropertyName("cpuUsage")]
    public double CpuUsage { get; init; } = cpuUsage;

    [Required]
    [JsonPropertyName("memoryUsage")]
    public double MemoryUsage { get; init; } = memoryUsage;

    protected override IEnumerable<object> GetAtomicValues()
    {        
        yield return base.GetAtomicValues();
        yield return CpuUsage;
        yield return MemoryUsage;
    }
}