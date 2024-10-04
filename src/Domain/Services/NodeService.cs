using Domain.Repositories;

namespace Domain.Services;

public sealed class NodeService(INodeEntityRepository nodeEntityRepository) : INodeService
{
    private readonly INodeEntityRepository _nodeEntityRepository = nodeEntityRepository;
    
    public async Task<IEnumerable<NodeEntity>> GetNodeEntitiesAsync(CancellationToken ct = default)
    {
        return await _nodeEntityRepository.GetAsync(o => true, ct);
    }

    public async Task<NodeEntity?> GetNodeEntityByIdAsync(Guid entityId, CancellationToken ct = default)
    {
        return await _nodeEntityRepository.GetAsync(entityId, ct);
    }

    public async Task<NodeEntity?> GetNodeEntityByNodeSelectorAsync(string nodeSelector, CancellationToken ct = default)
    {
        var queryResult = await _nodeEntityRepository.GetAsync(p => p.NodeSelector == nodeSelector, ct);

        return queryResult?.SingleOrDefault();
    }

    public async Task<IEnumerable<NodeEntity>> GetNodeEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default)
    {
        return await _nodeEntityRepository.GetAsync(r => r.Created >= startDate && r.Created <= (endDate ?? DateTime.UtcNow), ct);
    }

    public async Task<NodeEntity> AddNodeEntityAsync(string nodeSelector, IEnumerable<NodeMetrics>? metrics, CancellationToken ct = default)
    {
        var entity = new NodeEntity(nodeSelector, DateTime.UtcNow);

        if (metrics != null)
            entity.AddNodeMetrics(metrics);

        _nodeEntityRepository.Add(entity);

        await _nodeEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return entity;
    }

    public async Task<NodeEntity> UpdateNodeEntityAsync(NodeEntity entity, CancellationToken ct = default)
    {
        var updatedEntity = _nodeEntityRepository.Update(entity);

        await _nodeEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return updatedEntity;
    }

    public async Task<bool> DeleteNodeEntityAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _nodeEntityRepository.GetAsync(entityId, ct);

        if (entity is not null) _nodeEntityRepository.Delete(entity);

        return await _nodeEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);
    }

    public async Task<NodeMetrics> AddOrUpdateNodeMetricsAsync(Guid entityId, string label, double cpuUsage, double memoryUsage, CancellationToken ct = default)
    {
        var metrics = new NodeMetrics(label, cpuUsage, memoryUsage);
        var entity = await _nodeEntityRepository.GetAsync(entityId, ct);

        if (entity is not null && entity.Metrics != null && !entity.Metrics.Any(o => o.Equals(metrics)))
        {
            entity.AddNodeMetrics(metrics);

            await UpdateNodeEntityAsync(entity, ct);
        }

        return metrics;
    }

    public async Task<bool> DeleteNodeMetricsAsync(Guid entityId, string? label, CancellationToken ct = default)
    {
        var entity = await _nodeEntityRepository.GetAsync(entityId, ct);

        if (entity is not null)
        {
            var query = entity.Metrics.AsQueryable();

            if (!string.IsNullOrWhiteSpace(label))
                query = query.Where(ci => ci.Label == label);

            foreach (var metrics in query.AsEnumerable())
                entity.RemoveNodeMetrics(metrics);

            await UpdateNodeEntityAsync(entity, ct);

            return true;
        }

        return false;
    }
}