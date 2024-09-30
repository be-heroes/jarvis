namespace Application.Telemetry;

public static partial class Logs
{
    [LoggerMessage(LogLevel.Information, "Starting the application with process id: {processId}.")]
    public static partial void LogStarting(this ILogger logger, int processId);

    [LoggerMessage(LogLevel.Information, "PodEntityReturnCount: `{count}` entities returned to client.")]
    public static partial void LogPodEntityReturnCount(this ILogger logger, int count);
}