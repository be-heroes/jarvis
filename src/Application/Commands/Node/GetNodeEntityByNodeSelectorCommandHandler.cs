namespace Application.Commands.Node;

public sealed class GetNodeEntityByNodeSelectorCommandHandler(INodeService nodeService) : ICommandHandler<GetNodeEntityByNodeSelectorCommand, NodeEntity?>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<NodeEntity?> Handle(GetNodeEntityByNodeSelectorCommand command, CancellationToken ct = default)
    {
        return await _nodeService.GetNodeEntityByNodeSelectorAsync(command.NodeSelector, ct);
    }
}