namespace Application.Commands.Node;

public sealed class GetNodeEntityByDateRangeCommandHandler(INodeService nodeService) : ICommandHandler<GetNodeEntityByDateRangeCommand, IEnumerable<NodeEntity>>
{
    private readonly INodeService _nodeService = nodeService ?? throw new ArgumentNullException(nameof(nodeService));

    public async Task<IEnumerable<NodeEntity>> Handle(GetNodeEntityByDateRangeCommand command, CancellationToken ct = default)
    {
        return await _nodeService.GetNodeEntityByDateRangeAsync(command.StartDate, command.EndDate, ct);
    }
}