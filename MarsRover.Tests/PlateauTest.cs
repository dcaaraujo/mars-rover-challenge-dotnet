namespace MarsRover.Tests;

public class PlateauTest
{
    private readonly Plateau _sut = new(5, 5);

    [Fact]
    public void CoordinatesAreWithinBounds()
    {
        bool result = _sut.IsWithinBounds(3, 3);
        Assert.True(result);
    }

    [Fact]
    public void XCoordinatesAreOutsideBounds()
    {
        bool result = _sut.IsWithinBounds(6, 5);
        Assert.False(result);

        result = _sut.IsWithinBounds(-1, 5);
        Assert.False(result);
    }


    [Fact]
    public void YCoordinatesAreOutsideBounds()
    {
        bool result = _sut.IsWithinBounds(3, 6);
        Assert.False(result);

        result = _sut.IsWithinBounds(3, -1);
        Assert.False(result);
    }

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
