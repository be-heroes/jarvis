using Domain.Repositories;

namespace Domain.Services;

public sealed class PodService(IPodEntityRepository podEntityRepository) : IPodService
{
    private readonly IPodEntityRepository _podEntityRepository = podEntityRepository;
    
    public async Task<IEnumerable<PodEntity>> GetPodEntitiesAsync(CancellationToken ct = default)
    {
        return await _podEntityRepository.GetAsync(o => true, ct);
    }

    public async Task<PodEntity?> GetPodEntityByIdAsync(Guid entityId, CancellationToken ct = default)
    {
        return await _podEntityRepository.GetAsync(entityId, ct);
    }

    public async Task<PodEntity?> GetPodEntityByPodSelectorAsync(string podSelector, CancellationToken ct = default)
    {
        var queryResult = await _podEntityRepository.GetAsync(p => p.PodSelector == podSelector, ct);

        return queryResult?.SingleOrDefault();
    }

    public async Task<IEnumerable<PodEntity>> GetPodEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default)
    {
        return await _podEntityRepository.GetAsync(r => r.Created >= startDate && r.Created <= (endDate ?? DateTime.UtcNow), ct);
    }

    public async Task<PodEntity> AddPodEntityAsync(string podSelector, IEnumerable<PodMetrics>? metrics, CancellationToken ct = default)
    {
        var entity = new PodEntity(podSelector, DateTime.UtcNow);

        if (metrics != null)
            entity.AddPodMetrics(metrics);

        _podEntityRepository.Add(entity);

        await _podEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return entity;
    }

    public async Task<PodEntity> UpdatePodEntityAsync(PodEntity entity, CancellationToken ct = default)
    {
        var updatedEntity = _podEntityRepository.Update(entity);

        await _podEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return updatedEntity;
    }

    public async Task<bool> DeletePodEntityAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _podEntityRepository.GetAsync(entityId, ct);

        if (entity is not null) _podEntityRepository.Delete(entity);

        return await _podEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);
    }

    public async Task<PodMetrics> AddOrUpdatePodMetricsAsync(Guid entityId, string label, double cpuUsage, double memoryUsage, CancellationToken ct = default)
    {
        var metrics = new PodMetrics(label, cpuUsage, memoryUsage);
        var entity = await _podEntityRepository.GetAsync(entityId, ct);

        if (entity is not null && entity.Metrics != null && !entity.Metrics.Any(o => o.Equals(metrics)))
        {
            entity.AddPodMetrics(metrics);

            await UpdatePodEntityAsync(entity, ct);
        }

        return metrics;
    }

    public async Task<bool> DeletePodMetricsAsync(Guid entityId, string? label, CancellationToken ct = default)
    {
        var entity = await _podEntityRepository.GetAsync(entityId, ct);

        if (entity is not null)
        {
            var query = entity.Metrics.AsQueryable();

            if (!string.IsNullOrWhiteSpace(label))
                query = query.Where(ci => ci.Label == label);

            foreach (var metrics in query.AsEnumerable())
                entity.RemovePodMetric(metrics);

            await UpdatePodEntityAsync(entity, ct);

            return true;
        }

        return false;
    }
}