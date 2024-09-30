namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class UpdatePodEntityCommand(PodEntity entity) : ICommand<PodEntity>
{
    [JsonPropertyName("entity")] 
    public PodEntity Entity { get; init; } = entity;
}