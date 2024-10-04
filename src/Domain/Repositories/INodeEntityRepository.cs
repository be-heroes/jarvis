namespace Domain.Repositories;

public interface INodeEntityRepository : IRepository<NodeEntity>
{
    Task<NodeEntity?> GetAsync(Guid entityId, CancellationToken ct = default);
}