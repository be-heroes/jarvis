namespace Application.Commands.Pod;

public sealed class GetPodEntityByPodSelectorCommandHandler(IPodService podService) : ICommandHandler<GetPodEntityByPodSelectorCommand, PodEntity?>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<PodEntity?> Handle(GetPodEntityByPodSelectorCommand command, CancellationToken ct = default)
    {
        return await _podService.GetPodEntityByPodSelectorAsync(command.PodSelector, ct);
    }
}