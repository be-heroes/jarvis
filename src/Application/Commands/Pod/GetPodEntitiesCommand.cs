namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class GetPodEntitiesCommand() : ICommand<IEnumerable<PodEntity>>
{
}