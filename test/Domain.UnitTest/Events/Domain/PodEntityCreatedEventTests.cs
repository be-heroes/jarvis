namespace Domain.UnitTest.Events.Domain;

public class PodEntityCreatedEventTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        PodEntityCreatedEvent sut;

        //Act
        sut = new PodEntityCreatedEvent(null);

        //Assert
        Assert.NotNull(sut);
        Assert.True(sut.Entity == null);
    }

    [Fact]
    public void AreNotEqual()
    {
        //Arrange
        var PodEntity = new PodEntity();
        var sut = new PodEntityCreatedEvent(PodEntity);

        //Act
        var anotherEvent = new PodEntityCreatedEvent(PodEntity);

        //Assert
        Assert.True(sut.Entity == PodEntity);
        Assert.True(anotherEvent.Entity == PodEntity);
        Assert.False(sut.Equals(PodEntity));
    }
}