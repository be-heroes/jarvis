namespace Application.Commands.Node;

public sealed class DeleteNodeMetricsCommandHandler(INodeService nodeService) : ICommandHandler<DeleteNodeMetricsCommand, bool>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<bool> Handle(DeleteNodeMetricsCommand command, CancellationToken cancellationToken = default)
    {
        return await _nodeService.DeleteNodeMetricsAsync(command.EntityId, command.Label, cancellationToken);
    }
}