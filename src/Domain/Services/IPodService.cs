namespace Domain.Services;

public interface IPodService : IService
{
    Task<IEnumerable<PodEntity>> GetPodEntitiesAsync(CancellationToken ct = default);
    Task<PodEntity?> GetPodEntityByIdAsync(Guid entityId, CancellationToken ct = default);
    Task<PodEntity?> GetPodEntityByPodSelectorAsync(string podSelector, CancellationToken ct = default);
    Task<IEnumerable<PodEntity>> GetPodEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default);
    Task<PodEntity> AddPodEntityAsync(string podSelector, IEnumerable<PodMetrics>? metrics, CancellationToken ct = default);
    Task<PodEntity> UpdatePodEntityAsync(PodEntity entity, CancellationToken ct = default);
    Task<bool> DeletePodEntityAsync(Guid entityId, CancellationToken ct = default);
    Task<PodMetrics> AddOrUpdatePodMetricsAsync(Guid entityId, string label, double cpuUsage, double memoryUsage, CancellationToken ct = default);
    Task<bool> DeletePodMetricsAsync(Guid entityId, string? label, CancellationToken ct = default);
}