using MarsRover;

namespace Game;

public class MarsRoverCmdLineGame(IInstructionParser parser)
{
    private readonly IInstructionParser _instructionParser = parser;

    public void Start()
    {
        var plateau = GetPlateau();
        while (true)
        {
            var rover = GetRover();
            var instructions = GetInstructions();

            rover.RunAllInstructions(instructions);
            if (plateau.IsWithinBounds(rover.X, rover.Y))
            {
                Console.WriteLine($"{rover.X} {rover.Y} {(char)rover.Direction}");
            }
            else
            {
                Console.WriteLine("Rover fell off the platform!");
            }
        }
    }

    private static Plateau GetPlateau()
    {
        var plateauInput = "";
        while (string.IsNullOrEmpty(plateauInput))
        {
            plateauInput = Console.ReadLine() ?? "";
        }
        return Plateau.Parse(plateauInput);
    }

    private static Rover GetRover()
    {
        string roverInput = "";
        while (string.IsNullOrEmpty(roverInput))
        {
            roverInput = Console.ReadLine() ?? "";
        }
        return Rover.Parse(roverInput!);
    }

    private IEnumerable<Instruction> GetInstructions()
    {
        var instructionsInput = "";
        while (string.IsNullOrEmpty(instructionsInput))
        {
            instructionsInput = Console.ReadLine() ?? "";
        }
        return _instructionParser.Parse(instructionsInput!);
    }
}
