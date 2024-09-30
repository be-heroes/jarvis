namespace Host.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PodController(ILogger<PodController> logger, IApplicationFacade facade) : ControllerBase
{
    private readonly IApplicationFacade _facade = facade;

    private readonly ILogger<PodController> _logger = logger;

    private readonly Counter<int> _requestCounter = Metrics.RequestMeter.CreateCounter<int>("request.counter", description: "Counts the number of requests serviced by the controller");

    [HttpGet]
    public async Task<IEnumerable<PodEntity>> GetPodEntitiesAsync(CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        //Initialize command to get all pod entities
        var command = new GetPodEntitiesCommand();

        // Dispatch command to application facade
        var entities = await _facade.Execute(command, ct);
        var entityCount = entities.Count();

        // Add a tag to the custom activity containing a entity count (replace Hello World!, even thou we love it)
        activity?.SetTag(nameof(entityCount), entityCount);

        // Log the number of entities returned
        _logger.LogPodEntityReturnCount(entityCount);

        // Return the found entities
        return entities;
    }

    //TODO: Implement controller actions for remaning commands
}