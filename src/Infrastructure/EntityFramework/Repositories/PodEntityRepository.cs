namespace Infrastructure.EntityFramework.Repositories;

public class PodEntityRepository(ApplicationContext context) : EntityFrameworkRepository<PodEntity, ApplicationContext>(context), IPodEntityRepository
{
    public override async Task<IEnumerable<PodEntity>> GetAsync(Expression<Func<PodEntity, bool>> filter, CancellationToken ct = default)
    {
        return await Task.Factory.StartNew(() =>
        {
            return _context.Pods.AsQueryable()
                .AsNoTracking()
                .Where(filter)
                .Include(i => i.Metrics)
                .AsEnumerable();
        }, ct);
    }

    public async Task<PodEntity?> GetAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _context.Pods.FindAsync(entityId, ct);

        if (entity is not null)
        {
            var entry = _context.Entry(entity);
            await entry.Reference(o => o.Metrics).LoadAsync(ct);
        }

        return entity;
    }
}