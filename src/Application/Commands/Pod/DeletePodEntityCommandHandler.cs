namespace Application.Commands.Pod;

public sealed class DeletePodEntityCommandHandler(IPodService podService) : ICommandHandler<DeletePodEntityCommand, bool>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<bool> Handle(DeletePodEntityCommand command, CancellationToken ct = default)
    {
        return await _podService.DeletePodEntityAsync(command.EntityId, ct);
    }
}