namespace MarsRover.Tests;

public class PlateauTest
{
    private readonly Plateau _sut = new(5, 5);

    [Theory]
    [InlineData(0, 0)]
    [InlineData(3, 3)]
    [InlineData(1, 2)]
    [InlineData(5, 5)]
    public void CoordinatesAreWithinBounds(int x, int y) => Assert.True(_sut.IsWithinBounds(x, y));

    [Theory]
    [InlineData(6, 5)]
    [InlineData(-1, 5)]
    [InlineData(6, 6)]
    [InlineData(3, -1)]
    public void CoordinatesAreOutsideBounds(int x, int y) => Assert.False(_sut.IsWithinBounds(x, y));

    [Fact]
    public void ParseFactoryMethodReturnsPlateau()
    {
        var sut = Plateau.Parse("5 4");
        Assert.Equal(5, sut.TopX);
        Assert.Equal(4, sut.TopY);
    }

    [Fact]
    public void ThrowsExceptionWhenGivenInvalidInput()
    {
        Assert.Throws<ArgumentException>(() => Plateau.Parse("T E S T"));
    }
}
