namespace Application.Commands.Node;

public sealed class UpdateNodeMetricsCommandHandler(INodeService nodeService) : ICommandHandler<UpdateNodeMetricsCommand, NodeMetrics>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<NodeMetrics> Handle(UpdateNodeMetricsCommand command, CancellationToken cancellationToken = default)
    {
        return await _nodeService.AddOrUpdateNodeMetricsAsync(command.EntityId, command.Label, command.CpuUsage, command.MemoryUsage, cancellationToken);
    }
}