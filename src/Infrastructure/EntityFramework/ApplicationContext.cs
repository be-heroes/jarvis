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
    public virtual DbSet<NodeEntity> Nodes { get; set; }

    public virtual DbSet<PodEntity> Pods { get; set; }

    public virtual DbSet<Domain.ValueObjects.Metrics> Metrics { get; set; }
}