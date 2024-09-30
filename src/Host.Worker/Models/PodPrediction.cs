namespace Host.Worker.Models;

public class PodPrediction
{
    [ColumnName("PredictedLabel")]
    public string OptimalNodeType { get; set; } = string.Empty;
}