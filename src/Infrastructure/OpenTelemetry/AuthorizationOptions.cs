/// <summary>
/// Represents the available options for authorization in OpenTelemetry.
/// </summary>
namespace Infrastructure.OpenTelemetry;

public enum AuthorizationOptions
{
    NoAuth,
    ServicePrincipal,
    SystemAssignedIdentity,
    UserAssignedIdentity
}