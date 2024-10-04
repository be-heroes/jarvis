namespace Application.Commands.Node;

public sealed class DeleteNodeEntityCommandHandler(INodeService nodeService) : ICommandHandler<DeleteNodeEntityCommand, bool>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<bool> Handle(DeleteNodeEntityCommand command, CancellationToken ct = default)
    {
        return await _nodeService.DeleteNodeEntityAsync(command.EntityId, ct);
    }
}