namespace Application.Commands.Pod;

public sealed class UpdatePodMetricsCommandHandler(IPodService podService) : ICommandHandler<UpdatePodMetricsCommand, PodMetrics>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<PodMetrics> Handle(UpdatePodMetricsCommand command, CancellationToken cancellationToken = default)
    {
        return await _podService.AddOrUpdatePodMetricsAsync(command.EntityId, command.Label, command.CpuUsage, command.MemoryUsage, cancellationToken);
    }
}