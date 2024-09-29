namespace emma_ultron_chronicler;

using Microsoft.ML.Data;

public class PodPrediction
{
    [ColumnName("PredictedLabel")]
    public string OptimalNodeType { get; set; } = string.Empty;
}