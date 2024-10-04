namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class GetNodeEntitiesCommand() : ICommand<IEnumerable<NodeEntity>>
{
}