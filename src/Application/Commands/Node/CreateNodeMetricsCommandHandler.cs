namespace Application.Commands.Node;

public sealed class CreateNodeMetricsCommandHandler(INodeService nodeService) : ICommandHandler<CreateNodeMetricsCommand, NodeMetrics>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<NodeMetrics> Handle(CreateNodeMetricsCommand command, CancellationToken cancellationToken = default)
    {
        return await _nodeService.AddOrUpdateNodeMetricsAsync(command.EntityId, command.Label, command.CpuUsage, command.MemoryUsage, cancellationToken);
    }
}