namespace Application.Commands.Pod;

public sealed class GetDomainEntityByDateRangeCommandHandler(IPodService podService) : ICommandHandler<GetPodEntityByDateRangeCommand, IEnumerable<PodEntity>>
{
    private readonly IPodService _domainService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<IEnumerable<PodEntity>> Handle(GetPodEntityByDateRangeCommand command, CancellationToken ct = default)
    {
        return await _domainService.GetPodEntityByDateRangeAsync(command.StartDate, command.EndDate, ct);
    }
}