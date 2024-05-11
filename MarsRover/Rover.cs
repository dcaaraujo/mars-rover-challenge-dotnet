namespace MarsRover;

public class Rover(int startX, int startY, Direction startDirection)
{
    public int X { get; private set; } = startX;

    public int Y { get; private set; } = startY;

    public Direction Direction { get; private set; } = startDirection;

    public static Rover Parse(string deployment)
    {
        var tokens = deployment.Split(' ');
        if (tokens.Length != 3)
        {
            throw new ArgumentException($"Could not construct rover with deployment: \"{deployment}\"");
        }
        var x = int.Parse(tokens[0]);
        var y = int.Parse(tokens[1]);
        var dir = (Direction) char.Parse(tokens[2]);
        return new(x, y, dir);
    }


    public void RunInstruction(Instruction instruction)
    {
        switch (instruction)
        {
            case Instruction.MoveForeward:
                MoveForward();
                break;
            case Instruction.TurnLeft:
                TurnLeft();
                break;
            case Instruction.TurnRight:
                TurnRight();
                break;
        }
    }

    private void MoveForward()
    {
        (int newX, int newY) = Direction switch
        {
            Direction.North => (X, Y + 1),
            Direction.South => (X, Y - 1),
            Direction.East => (X + 1, Y),
            Direction.West => (X - 1, Y),
            _ => throw new ArgumentOutOfRangeException()
        };
        X = newX;
        Y = newY;
    }

    private void TurnLeft()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.West,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            Direction.West => Direction.South,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void TurnRight()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.East,
            Direction.South => Direction.West,
            Direction.East => Direction.South,
            Direction.West => Direction.North,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

public enum Direction
{
    North = 'N',
    South = 'S',
    East = 'E',
    West = 'W'
}

public enum Instruction
{
    TurnLeft = 'L',
    TurnRight = 'R',
    MoveForeward = 'M'
}
