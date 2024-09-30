namespace Infrastructure.EntityFramework;

public class ApplicationContext : EntityContext
{
    public ApplicationContext()
    {
    }

#pragma warning disable CS8625
    public ApplicationContext(DbContextOptions options, IMediator? mediator = default, IDictionary<Type, IEnumerable<IView>> seedData = default) : base(options)
    {
    }
#pragma warning restore CS8625
    public virtual DbSet<PodEntity> Entities { get; set; }

    public virtual DbSet<PodMetrics> Metrics { get; set; }
}