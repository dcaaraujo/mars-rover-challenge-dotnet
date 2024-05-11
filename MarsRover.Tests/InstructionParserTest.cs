namespace MarsRover.Tests;

public class InstructionParserTest
{
    private readonly IInstructionParser _sut = new InstructionParser();

    [Fact]
    public void CanParseInstructions()
    {
        const string inputStr = "LMLMLMRMM";
        IEnumerable<Instruction> expectedInstructions = [
            Instruction.TurnLeft,
            Instruction.MoveForeward,
            Instruction.TurnLeft,
            Instruction.MoveForeward,
            Instruction.TurnLeft,
            Instruction.MoveForeward,
            Instruction.TurnRight,
            Instruction.MoveForeward,
            Instruction.MoveForeward
        ];
        var instructions = _sut.Parse(inputStr);
        Assert.Equal(inputStr.Length, instructions.Count());
        Assert.Equal(expectedInstructions, instructions);
    }

    [Fact]
    public void ThrowsExceptionWhenGivenInvalidInput()
    {
        Assert.Throws<ArgumentException>(() => _sut.Parse("LOL"));
    }
}
