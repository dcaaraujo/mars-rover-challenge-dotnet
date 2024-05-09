
namespace MarsRover;

public record Plateau(int TopX, int TopY)
{
    public bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x <= TopX && y >= 0 && y <= TopY;
    }
}
