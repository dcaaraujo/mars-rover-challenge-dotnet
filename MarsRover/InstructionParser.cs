namespace MarsRover;

public interface IInstructionParser
{
    IEnumerable<Instruction> Parse(string input);
}

public class InstructionParser : IInstructionParser
{
    public IEnumerable<Instruction> Parse(string input)
    {
        if (ContainsInvalidInstructions(input))
        {
            throw new ArgumentException($"Parsed instructions \"{input}\" and found an invalid instruction.");
        }
        return input.ToUpper().ToCharArray().Select(i => (Instruction)i);
    }

    private static bool ContainsInvalidInstructions(string input)
    {
        foreach (var c in input)
        {
            if (!Enum.IsDefined((Instruction)c))
            {
                return true;
            }
        }
        return false;
    }
}
