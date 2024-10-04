namespace Application.Commands.Node;

public sealed class CreateNodeEntityCommandHandler(INodeService nodeService) : ICommandHandler<CreateNodeEntityCommand, NodeEntity>, ICommandHandler<CreateNodeEntityCommand, IAggregateRoot>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<NodeEntity> Handle(CreateNodeEntityCommand command, CancellationToken ct = default)
    {
        return await _nodeService.AddNodeEntityAsync(command.NodeSelector, command.Metrics, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<CreateNodeEntityCommand, IAggregateRoot>.Handle(CreateNodeEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<CreateNodeEntityCommand, IAggregateRoot>.Handle(CreateNodeEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}