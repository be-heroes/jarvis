namespace Host.Worker.Services;

public class ChroniclerService(ILogger<ChroniclerService> logger) : BackgroundService
{
    private readonly ILogger<ChroniclerService> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Chronicling pod metrics...");
            
            await foreach (var pod in GetPodMetrics(stoppingToken))
            {
                // TODO: Persist pod metrics to DB
            }

            _logger.LogInformation("Chronicled pod metrics...");

            // TODO : Make this configurable
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }

    private static async IAsyncEnumerable<Domain.ValueObjects.PodMetrics> GetPodMetrics([EnumeratorCancellation] CancellationToken stoppingToken)
    {
        using IKubernetes client = new Kubernetes(KubernetesClientConfiguration.BuildDefaultConfig());

        var pods = await client.GetKubernetesPodsMetricsAsync().WaitAsync(stoppingToken);

        foreach(var pod in pods.Items) {
            var labelString = pod.Labels().SelectMany(kvp => $"{kvp.Key}={kvp.Value}").Concat(";").ToString()!;
            var memoryUsage = pod.Containers.Sum(c => c.Usage["memory"].ToDouble());
            var CpuUsage = pod.Containers.Sum(c => c.Usage["cpu"].ToDouble());

            yield return new Domain.ValueObjects.PodMetrics(labelString, pod.Metadata.Name, CpuUsage, memoryUsage);
        }
    }
}
