namespace Domain.Repositories;

public interface IPodEntityRepository : IRepository<PodEntity>
{
    Task<PodEntity?> GetAsync(Guid entityId, CancellationToken ct = default);
}