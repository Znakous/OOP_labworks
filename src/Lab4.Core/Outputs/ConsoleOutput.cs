namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;

public class ConsoleOutput : IOutput
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}