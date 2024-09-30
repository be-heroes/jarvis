namespace Application.Commands.Pod;

public sealed class CreatePodEntityCommandHandler(IPodService podService) : ICommandHandler<CreatePodEntityCommand, PodEntity>, ICommandHandler<CreatePodEntityCommand, IAggregateRoot>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<PodEntity> Handle(CreatePodEntityCommand command, CancellationToken ct = default)
    {
        return await _podService.AddPodEntityAsync(command.PodSelector, command.Metrics, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<CreatePodEntityCommand, IAggregateRoot>.Handle(CreatePodEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<CreatePodEntityCommand, IAggregateRoot>.Handle(CreatePodEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}