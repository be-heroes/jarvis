namespace Application.IntegrationTest;

public class ApplicationFacadeTests : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _serviceProviderFixture;

    public ApplicationFacadeTests(ServiceProviderFixture serviceProviderFixture)
    {
        _serviceProviderFixture = serviceProviderFixture;
    }

    [Fact]
    public async Task CanProcessCommand()
    {
        //Arrange
        var sut = _serviceProviderFixture.Provider.GetService<IApplicationFacade>();
        var testCommand = new CreatePodEntityCommand("podSelector", []);

        //Act
        var result = await sut.Execute(testCommand);

        //Assert
        Assert.NotNull(result);
    }
}