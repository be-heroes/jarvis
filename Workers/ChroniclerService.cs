namespace emma_ultron_chronicler.Workers;

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class ChroniclerService(ILogger<ChroniclerService> logger) : BackgroundService
{
    private readonly ILogger<ChroniclerService> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Monitoring pod resource usage...");

            var podMetrics = GetPodMetrics();
            
            // TODO: Store podMetrics in data store

            _logger.LogInformation("Pod metrics collected: {metrics}", podMetrics);

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }

    private static double ParseCpu(string cpuString)
    {
        return double.Parse(cpuString.Replace("m", ""));
    }

    private static double ParseMemory(string memoryString)
    {
        return double.Parse(memoryString.Replace("Mi", ""));
    }

    private static string GetPodMetrics()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "kubectl",
                Arguments = "top pods",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();

        string output = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return output;
    }
}
