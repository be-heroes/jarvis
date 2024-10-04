namespace Infrastructure.EntityFramework.Repositories;

public class NodeEntityRepository(ApplicationContext context) : EntityFrameworkRepository<NodeEntity, ApplicationContext>(context), INodeEntityRepository
{
    public override async Task<IEnumerable<NodeEntity>> GetAsync(Expression<Func<NodeEntity, bool>> filter, CancellationToken ct = default)
    {
        return await Task.Factory.StartNew(() =>
        {
            return _context.Nodes.AsQueryable()
                .AsNoTracking()
                .Where(filter)
                .Include(i => i.Metrics)
                .AsEnumerable();
        }, ct);
    }

    public async Task<NodeEntity?> GetAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _context.Nodes.FindAsync(entityId, ct);

        if (entity is not null)
        {
            var entry = _context.Entry(entity);
            await entry.Reference(o => o.Metrics).LoadAsync(ct);
        }

        return entity;
    }
}