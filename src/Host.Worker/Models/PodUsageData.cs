namespace Host.Worker.Models;

public class PodUsageData
{
    public string NodeType { get; set; } = string.Empty;

    public float CpuUsage { get; set; }

    public float MemoryUsage { get; set; }
}