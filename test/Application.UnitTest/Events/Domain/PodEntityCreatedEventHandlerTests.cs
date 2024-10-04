namespace Application.UnitTest.Events.Domain;

public class PodEntityCreatedEventHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockMediator = new Mock<IMediator>();
        var sut = new PodEntityCreatedEventHandler(mockMapper.Object, mockMediator.Object);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(hashCode, sut.GetHashCode());

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanHandleEvent()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockMediator = new Mock<IMediator>();
        var sut = new PodEntityCreatedEventHandler(mockMapper.Object, mockMediator.Object);

        //Act
        await sut.Handle(new PodEntityCreatedEvent(new PodEntity()));

        //Assert
        Mock.VerifyAll();
    }
}