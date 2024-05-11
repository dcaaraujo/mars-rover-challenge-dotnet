namespace MarsRover.Tests;

public class RoverTest
{
    [Theory]
    [InlineData("1 2 N", 1, 2, Direction.North)]
    [InlineData("3 3 E", 3, 3, Direction.East)]
    public void ParsingFactoryMethodReturnsRoverWithCorrectConfiguration(string deployment, int expectedX, int expectedY, Direction expectedDirection)
    {
        var sut = Rover.Parse(deployment);
        Assert.Equal(expectedX, sut.X);
        Assert.Equal(expectedY, sut.Y);
        Assert.Equal(expectedDirection, sut.Direction);
    }

    [Theory]
    [InlineData(Direction.North, 4, 6)]
    [InlineData(Direction.South, 4, 4)]
    [InlineData(Direction.East, 5, 5)]
    [InlineData(Direction.West, 3, 5)]
    public void RoverMovesForward(Direction direction, int expectedX, int expectedY)
    {
        var sut = new Rover(4, 5, direction);
        sut.RunInstruction(Instruction.MoveForeward);
        Assert.Equal(expectedX, sut.X);
        Assert.Equal(expectedY, sut.Y);
    }

    [Theory]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.South, Direction.East)]
    [InlineData(Direction.East, Direction.North)]
    [InlineData(Direction.West, Direction.South)]
    public void RoverTurnsLeft(Direction currentDirection, Direction expectedDirection)
    {
        var sut = new Rover(4, 5, currentDirection);
        sut.RunInstruction(Instruction.TurnLeft);
        Assert.Equal(expectedDirection, sut.Direction);
    }

    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.East, Direction.South)]
    [InlineData(Direction.West, Direction.North)]
    public void RoverTurnsRight(Direction currentDirection, Direction expectedDirection)
    {
        var sut = new Rover(4, 5, currentDirection);
        sut.RunInstruction(Instruction.TurnRight);
        Assert.Equal(expectedDirection, sut.Direction);
    }
}
