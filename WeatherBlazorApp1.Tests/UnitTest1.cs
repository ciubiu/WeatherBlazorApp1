namespace WeatherBlazorApp1.Tests;

public class MyTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        int expected = 5;
        int actual = 2 + 3;

        // Act & Assert
        Assert.Equal(expected, actual);
    }
}