namespace Infrastructure.Events.Node;

public class NodeEntityCreatedIntegrationEventHandler(IProducer<Ignore, IIntegrationEvent> producer) : IEventHandler<NodeEntityCreatedIntegrationEvent>
{
    private readonly Counter<int> _eventCounter = Metrics.EventMeter.CreateCounter<int>("event.counter", description: "Counts the number of events processed by the handler");

    private readonly IProducer<Ignore, IIntegrationEvent> _producer = producer;

    public async Task Handle(NodeEntityCreatedIntegrationEvent notification, CancellationToken ct = default)
    {
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}",
            MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _eventCounter.Add(1);

        // Create topic if it does not exist
        using (var adminClient = new DependentAdminClientBuilder(_producer.Handle).Build())
        {
            var metaData = adminClient.GetMetadata(TimeSpan.FromSeconds(5));
            var topicInfo = metaData.Topics.Where(tp => string.Equals(notification.Id, tp.Topic, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (topicInfo == null)
                await adminClient.CreateTopicsAsync([new TopicSpecification { Name = notification.Id, ReplicationFactor = 1, NumPartitions = 1 }]);
        }

        // Produce message to topic
        await _producer.ProduceAsync(notification.Id, new Message<Ignore, IIntegrationEvent> { Value = notification }, ct);
    }
}