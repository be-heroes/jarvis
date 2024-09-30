namespace Application.Telemetry;

/// <summary>
///     Represents a telemetry service.
/// </summary>
public static class Service
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    public static string Name { get; } = typeof(Service).AssemblyQualifiedName.ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    public static string Version { get; } = typeof(Service).Assembly.ManifestModule.ModuleVersionId.ToString();
}