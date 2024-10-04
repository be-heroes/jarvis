namespace Application.Commands.Pod;

public sealed class GetPodEntityByDateRangeCommandHandler(IPodService podService) : ICommandHandler<GetPodEntityByDateRangeCommand, IEnumerable<PodEntity>>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<IEnumerable<PodEntity>> Handle(GetPodEntityByDateRangeCommand command, CancellationToken ct = default)
    {
        return await _podService.GetPodEntityByDateRangeAsync(command.StartDate, command.EndDate, ct);
    }
}