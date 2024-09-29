namespace emma_ultron_chronicler.Workers;

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.ML;

public class ScholarService(ILogger<ScholarService> logger) : BackgroundService
{
    private readonly ILogger<ScholarService> _logger = logger;

    public PredictionEngine<PodUsageData, PodPrediction>? PredictionEngine { get; private set; } 

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var context = new MLContext();

            // TODO: Load data from DB, instead of CSV
            IDataView dataView = context.Data.LoadFromTextFile<PodUsageData>("pod_metrics_data.csv", separatorChar: ',', hasHeader: true);

            _logger.LogInformation("Training model...");

            var pipeline = context.Transforms.Conversion.MapValueToKey("PodType")
                .Append(context.Transforms.Concatenate("Features", "CpuUsage", "MemoryUsage"))
                .Append(context.Transforms.NormalizeMinMax("Features"))
                .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy("PodType", "Features"))
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            _logger.LogInformation("Fitting model...");

            var model = pipeline.Fit(dataView);
            
            _logger.LogInformation("Initializing prediction engine...");

            PredictionEngine = context.Model.CreatePredictionEngine<PodUsageData, PodPrediction>(model);
            
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}
