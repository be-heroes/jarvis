namespace Application.Commands.Pod;

public sealed class DeletePodMetricsCommandHandler(IPodService podService) : ICommandHandler<DeletePodMetricsCommand, bool>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<bool> Handle(DeletePodMetricsCommand command, CancellationToken cancellationToken = default)
    {
        return await _podService.DeletePodMetricsAsync(command.EntityId, command.PodSelector, command.Label, cancellationToken);
    }
}