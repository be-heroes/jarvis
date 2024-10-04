namespace Application.Commands.Node;

public sealed class UpdateNodeEntityCommandHandler(INodeService nodeService) : ICommandHandler<UpdateNodeEntityCommand, NodeEntity>, ICommandHandler<UpdateNodeEntityCommand, IAggregateRoot>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<NodeEntity> Handle(UpdateNodeEntityCommand command, CancellationToken ct = default)
    {
        return await _nodeService.UpdateNodeEntityAsync(command.Entity, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<UpdateNodeEntityCommand, IAggregateRoot>.Handle(UpdateNodeEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<UpdateNodeEntityCommand, IAggregateRoot>.Handle(UpdateNodeEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}