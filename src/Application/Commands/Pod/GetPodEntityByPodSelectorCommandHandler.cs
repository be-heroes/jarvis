namespace Application.Commands.Pod;

public sealed class GetPodEntityByPodSelectorCommandHandler(IPodService podService) : ICommandHandler<GetPodEntityByPodSelectorCommand, PodEntity?>
{
    private readonly IPodService _domainService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<PodEntity?> Handle(GetPodEntityByPodSelectorCommand command, CancellationToken ct = default)
    {
        return await _domainService.GetPodEntityByPodSelectorAsync(command.PodSelector, ct);
    }
}