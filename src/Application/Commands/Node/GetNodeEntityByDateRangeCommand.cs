namespace Application.Commands.Node;

[method: JsonConstructor]
public sealed class GetNodeEntityByDateRangeCommand(DateTime startDate, DateTime? endDate) : ICommand<IEnumerable<NodeEntity>>
{
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; init; } = startDate;

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; } = endDate;
}