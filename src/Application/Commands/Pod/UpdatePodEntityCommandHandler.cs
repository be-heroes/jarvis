namespace Application.Commands.Pod;

public sealed class UpdatePodEntityCommandHandler(IPodService podService) : ICommandHandler<UpdatePodEntityCommand, PodEntity>, ICommandHandler<UpdatePodEntityCommand, IAggregateRoot>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<PodEntity> Handle(UpdatePodEntityCommand command, CancellationToken ct = default)
    {
        return await _podService.UpdatePodEntityAsync(command.Entity, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<UpdatePodEntityCommand, IAggregateRoot>.Handle(UpdatePodEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<UpdatePodEntityCommand, IAggregateRoot>.Handle(UpdatePodEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}