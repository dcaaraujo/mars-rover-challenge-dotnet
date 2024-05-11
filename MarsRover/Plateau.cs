namespace MarsRover;

public record Plateau(int TopX, int TopY)
{
    public static Plateau Parse(string input)
    {
        var tokens = input.Trim().Split(' ');
        if (tokens.Length != 2)
        {
            throw new ArgumentException($"Could not plateau with input: \"{input}\"");
        }
        var x = int.Parse(tokens[0]);
        var y = int.Parse(tokens[1]);
        return new(x, y);
    }


    public bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x <= TopX && y >= 0 && y <= TopY;
    }
}
