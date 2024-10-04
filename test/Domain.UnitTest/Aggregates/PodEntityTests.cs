namespace Domain.UnitTest.Aggregates;

public class PodEntityTests
{
    [Fact]
    public void CanBeConstructed()
    {
        var sut = new PodEntity();

        Assert.NotNull(sut);
        Assert.True(sut.DomainEvents.Count == 1);
        Assert.Contains(sut.DomainEvents, i => i is PodEntityCreatedEvent);
    }

    [Fact]
    public void CanDetectValidConstruction()
    {
        //Arrange
        var sut = new PodEntity();
        var validationCtx = new ValidationContext(this);

        //Act
        var validationResults = sut.Validate(validationCtx);

        //Assert
        Assert.True(!validationResults.Any());
        Assert.Contains(sut.DomainEvents, i => i is PodEntityCreatedEvent);
    }
}