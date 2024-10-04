namespace Domain.UnitTest.Services;

public class CostServiceTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        PodService sut;
        var mockRepository = new Mock<IPodEntityRepository>();

        //Act
        sut = new PodService(mockRepository.Object);

        //Assert
        Assert.NotNull(sut);

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanAddPodEntity()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IPodEntityRepository>();
        var fakeAggregate = new PodEntity();

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.Add(It.IsAny<PodEntity>())).Returns(fakeAggregate);

        var sut = new PodService(mockRepository.Object);

        //Act
        var result = await sut.AddPodEntityAsync("podSelector", new[] { new PodMetrics("label", "podSelector", 2.0, 2.0) });

        //Assert
        Assert.NotNull(result);

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanDeletePodEntity()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IPodEntityRepository>();
        var fakeAggregate = new PodEntity();

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeAggregate));
        mockRepository.Setup(m => m.Delete(It.IsAny<PodEntity>()));

        var sut = new PodService(mockRepository.Object);

        //Act
        await sut.DeletePodEntityAsync(Guid.NewGuid());

        //Assert
        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanDeletePodMetrics()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IPodEntityRepository>();
        var fakeAggregate = new PodEntity();

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeAggregate));
        mockRepository.Setup(m => m.Delete(It.IsAny<PodEntity>()));

        var sut = new PodService(mockRepository.Object);

        //Act
        await sut.DeletePodMetricsAsync(Guid.NewGuid(), "a", "b");

        //Assert
        Mock.VerifyAll();
    }
}