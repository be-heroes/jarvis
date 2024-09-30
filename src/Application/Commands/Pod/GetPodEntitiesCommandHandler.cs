namespace Application.Commands.Pod;

public sealed class GetPodEntitiesCommandHandler(IPodService podService) : ICommandHandler<GetPodEntitiesCommand, IEnumerable<PodEntity>>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<IEnumerable<PodEntity>> Handle(GetPodEntitiesCommand command, CancellationToken ct = default)
    {
        return await _podService.GetPodEntitiesAsync(ct);
    }
}