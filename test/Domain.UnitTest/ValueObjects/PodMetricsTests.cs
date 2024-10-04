namespace Domain.UnitTest.ValueObjects;

public class PodMetricsTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        PodMetrics sut;

        //Act
        sut = new PodMetrics("label", 2.0, 2.0);

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("label", sut.Label);
        Assert.Equal(2.0, sut.CpuUsage);
        Assert.Equal(2.0, sut.MemoryUsage);
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new PodMetrics("label", 2.0, 2.0);

        //Act
        var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        //Assert
        Assert.NotNull(JsonDocument.Parse(payload));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        PodMetrics sut;

        //Act
        sut = JsonSerializer.Deserialize<PodMetrics>("{\"label\":\"label\",\"cpuUsage\":2.0,\"memoryUsage\":2.0}");

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("label", sut.Label);
        Assert.Equal(2.0, sut.CpuUsage);
        Assert.Equal(2.0, sut.MemoryUsage);
    }
}