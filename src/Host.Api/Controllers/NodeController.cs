namespace Host.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NodeController(ILogger<NodeController> logger, IApplicationFacade facade) : ControllerBase
{
    private readonly IApplicationFacade _facade = facade;

    private readonly ILogger<NodeController> _logger = logger;

    private readonly Counter<int> _requestCounter = Metrics.RequestMeter.CreateCounter<int>("request.counter", description: "Counts the number of requests serviced by the controller");

    [HttpGet]
    public async Task<IEnumerable<NodeEntity>> GetNodeEntitiesAsync(CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        //Initialize command to get all node entities
        var command = new GetNodeEntitiesCommand();

        // Dispatch command to application facade
        var entities = await _facade.Execute(command, ct);
        var entityCount = entities.Count();

        // Add a tag to the custom activity containing a entity count
        activity?.SetTag(nameof(entityCount), entityCount);

        // Log the number of entities returned
        _logger.LogPodEntityReturnCount(entityCount);

        // Return the found entities
        return entities;
    }

    //TODO: Implement controller actions for remaning commands
}