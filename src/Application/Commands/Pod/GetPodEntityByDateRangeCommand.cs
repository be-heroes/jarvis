namespace Application.Commands.Pod;

[method: JsonConstructor]
public sealed class GetPodEntityByDateRangeCommand(DateTime startDate, DateTime? endDate) : ICommand<IEnumerable<PodEntity>>
{
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; init; } = startDate;

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; } = endDate;
}