namespace Domain.Services;

public interface INodeService : IService
{
    Task<IEnumerable<NodeEntity>> GetNodeEntitiesAsync(CancellationToken ct = default);
    Task<NodeEntity?> GetNodeEntityByIdAsync(Guid entityId, CancellationToken ct = default);
    Task<NodeEntity?> GetNodeEntityByNodeSelectorAsync(string podSelector, CancellationToken ct = default);
    Task<IEnumerable<NodeEntity>> GetNodeEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default);
    Task<NodeEntity> AddNodeEntityAsync(string podSelector, IEnumerable<NodeMetrics>? metrics, CancellationToken ct = default);
    Task<NodeEntity> UpdateNodeEntityAsync(NodeEntity entity, CancellationToken ct = default);
    Task<bool> DeleteNodeEntityAsync(Guid entityId, CancellationToken ct = default);
    Task<NodeMetrics> AddOrUpdateNodeMetricsAsync(Guid entityId, string label, double cpuUsage, double memoryUsage, CancellationToken ct = default);
    Task<bool> DeleteNodeMetricsAsync(Guid entityId, string? label, CancellationToken ct = default);
}