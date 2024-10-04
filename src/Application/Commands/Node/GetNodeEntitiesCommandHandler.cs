namespace Application.Commands.Node;

public sealed class GetNodeEntitiesCommandHandler(INodeService nodeService) : ICommandHandler<GetNodeEntitiesCommand, IEnumerable<NodeEntity>>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<IEnumerable<NodeEntity>> Handle(GetNodeEntitiesCommand command, CancellationToken ct = default)
    {
        return await _nodeService.GetNodeEntitiesAsync(ct);
    }
}