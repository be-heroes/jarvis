using BeHeroes.CodeOps.Abstractions.Data;

namespace Application.IntegrationTest.Fixtures;

public class ServiceProviderFixture : IDisposable
{
    public IServiceProvider Provider { get; init; }

    public ServiceProviderFixture()
    {
        var services = new ServiceCollection();

        services.AddApplication();

        var repositoryMock = new Mock<IPodEntityRepository>();

        repositoryMock.Setup(x => x.UnitOfWork).Returns(new Mock<IUnitOfWork>().Object);

        services.AddTransient((services) => { return repositoryMock.Object; });

        Provider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
    }
}
