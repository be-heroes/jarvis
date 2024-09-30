/// <summary>
/// Represents the available options for configuring OpenTelemetry exporter.
/// </summary>
namespace Infrastructure.OpenTelemetry;

public class OpenTelemetryExporterOptions
{
    public string? BifrostEnvironmentId { get; set; }

    public string? Endpoint { get; set; }
}