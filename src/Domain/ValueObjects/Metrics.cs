namespace Domain.ValueObjects;

[method: JsonConstructor]
public abstract class Metrics(string label) : ValueObject
{
    [Required]
    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Label;
    }
}